using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Assets_Editor;
using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using pb = global::Google.Protobuf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tibia.Protobuf.Staticdata;

namespace Assets_Editor
{
    public static class Utils
    {

        static readonly int[] Outfit_lookup_table = {
        0xFFFFFF, 0xFFD4BF, 0xFFE9BF, 0xFFFFBF, 0xE9FFBF, 0xD4FFBF,
        0xBFFFBF, 0xBFFFD4, 0xBFFFE9, 0xBFFFFF, 0xBFE9FF, 0xBFD4FF,
        0xBFBFFF, 0xD4BFFF, 0xE9BFFF, 0xFFBFFF, 0xFFBFE9, 0xFFBFD4,
        0xFFBFBF, 0xDADADA, 0xBF9F8F, 0xBFAF8F, 0xBFBF8F, 0xAFBF8F,
        0x9FBF8F, 0x8FBF8F, 0x8FBF9F, 0x8FBFAF, 0x8FBFBF, 0x8FAFBF,
        0x8F9FBF, 0x8F8FBF, 0x9F8FBF, 0xAF8FBF, 0xBF8FBF, 0xBF8FAF,
        0xBF8F9F, 0xBF8F8F, 0xB6B6B6, 0xBF7F5F, 0xBFAF8F, 0xBFBF5F,
        0x9FBF5F, 0x7FBF5F, 0x5FBF5F, 0x5FBF7F, 0x5FBF9F, 0x5FBFBF,
        0x5F9FBF, 0x5F7FBF, 0x5F5FBF, 0x7F5FBF, 0x9F5FBF, 0xBF5FBF,
        0xBF5F9F, 0xBF5F7F, 0xBF5F5F, 0x919191, 0xBF6A3F, 0xBF943F,
        0xBFBF3F, 0x94BF3F, 0x6ABF3F, 0x3FBF3F, 0x3FBF6A, 0x3FBF94,
        0x3FBFBF, 0x3F94BF, 0x3F6ABF, 0x3F3FBF, 0x6A3FBF, 0x943FBF,
        0xBF3FBF, 0xBF3F94, 0xBF3F6A, 0xBF3F3F, 0x6D6D6D, 0xFF5500,
        0xFFAA00, 0xFFFF00, 0xAAFF00, 0x54FF00, 0x00FF00, 0x00FF54,
        0x00FFAA, 0x00FFFF, 0x00A9FF, 0x0055FF, 0x0000FF, 0x5500FF,
        0xA900FF, 0xFE00FF, 0xFF00AA, 0xFF0055, 0xFF0000, 0x484848,
        0xBF3F00, 0xBF7F00, 0xBFBF00, 0x7FBF00, 0x3FBF00, 0x00BF00,
        0x00BF3F, 0x00BF7F, 0x00BFBF, 0x007FBF, 0x003FBF, 0x0000BF,
        0x3F00BF, 0x7F00BF, 0xBF00BF, 0xBF007F, 0xBF003F, 0xBF0000,
        0x242424, 0x7F2A00, 0x7F5500, 0x7F7F00, 0x557F00, 0x2A7F00,
        0x007F00, 0x007F2A, 0x007F55, 0x007F7F, 0x00547F, 0x002A7F,
        0x00007F, 0x2A007F, 0x54007F, 0x7F007F, 0x7F0055, 0x7F002A,
        0x7F0000,
        };
        public static System.Windows.Media.Color Get8Bit(int color)
        {
            System.Windows.Media.Color RgbColor = new System.Windows.Media.Color
            {
                R = (byte)(color / 36 % 6 * 51),
                G = (byte)(color / 6 % 6 * 51),
                B = (byte)(color % 6 * 51)
            };
            return RgbColor;
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        public static System.Drawing.Color ColorizePixelOutfit(int color, int a, int b, int c)
        {
            int value = (int)Outfit_lookup_table.GetValue(color);
            int ro = (value & 0xFF0000) >> 16;
            int go = (value & 0xFF00) >> 8;
            int bo = value & 0xFF;
            return System.Drawing.Color.FromArgb((a * (ro * 100 / 255)) / 100, (b * (go * 100 / 255)) / 100, (c * (bo * 100 / 255)) / 100);
        }
        public static BitmapImage BitmapColourizeSource(MemoryStream templateStream, MemoryStream outfitStream, int head, int body, int legs, int feet)
        {
            System.Drawing.Color Body = System.Drawing.Color.FromArgb(255, 0, 0);
            System.Drawing.Color Legs = System.Drawing.Color.FromArgb(0, 255, 0);
            System.Drawing.Color Head = System.Drawing.Color.FromArgb(255, 255, 0);
            System.Drawing.Color Foot = System.Drawing.Color.FromArgb(0, 0, 255);
            Bitmap img = new Bitmap(templateStream);
            Bitmap outfitImg = new Bitmap(outfitStream);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    System.Drawing.Color templatepixel = img.GetPixel(i, j);
                    System.Drawing.Color outfit = outfitImg.GetPixel(i, j);
                    if (templatepixel == outfit)
                        continue;

                    int ro = (outfit.ToArgb() >> 16) & 0xFF;
                    int go = (outfit.ToArgb() >> 8) & 0xFF;
                    int bo = outfit.ToArgb() & 0xFF;

                    if (templatepixel == Body)
                        outfitImg.SetPixel(i, j, ColorizePixelOutfit(body, ro, go, bo));
                    else if (templatepixel == Legs)
                        outfitImg.SetPixel(i, j, ColorizePixelOutfit(legs, ro, go, bo));
                    else if (templatepixel == Head)
                        outfitImg.SetPixel(i, j, ColorizePixelOutfit(head, ro, go, bo));
                    else if (templatepixel == Foot)
                        outfitImg.SetPixel(i, j, ColorizePixelOutfit(feet, ro, go, bo));
                    else
                        continue;
                }
            }
            var memory = new MemoryStream();
            outfitImg.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            return BitmapToBitmapImage(memory);
        }
        public static BitmapImage BitmapToBitmapImage(MemoryStream stream)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            bitmap.StreamSource = stream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }
        public static BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return bitmapImage;
        }

        public static void RegisterNewMonsterStaticData(Monster cacheData)
        {
            foreach (var data_monster in MainWindow.StaticData.Monster)
            {
                if (data_monster.Raceid == cacheData.Raceid)
                {
                    MainWindow.StaticData.Monster.Remove(data_monster);
                    break;
                }
            }
            Monster monster = new Monster();
            monster.MergeFrom(cacheData);
            MainWindow.StaticData.Monster.Add(monster);
        }
            public static void CompileStaticData()
        {
            File.Copy(System.IO.Path.Combine(MainWindow._assetsPath, "catalog-content.json"), System.IO.Path.Combine(MainWindow._assetsPath, "catalog-content.json-bak"), true);
            File.Copy(MainWindow._staticPath, MainWindow._staticPath + "-bak", true);

            using (StreamWriter file = File.CreateText(MainWindow._assetsPath + "\\catalog-content.json"))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new DatEditor.LowercaseContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                };
                serializer.Serialize(file, MainWindow.catalog);
            }
            var output = File.Create(MainWindow._staticPath);
            MainWindow.StaticData.WriteTo(output);
            output.Close();
        }

        public static List<T> GetLogicalChildCollection<T>(this DependencyObject parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent, logicalCollection);
            return logicalCollection;
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
        public static BitmapSource BitmapFromControl(Visual target, double dpiX, double dpiY, int width, int height)
        {
            if (target == null)
            {
                return null;
            }
            Rect bounds = new Rect(VisualTreeHelper.GetDescendantBounds(target).X, VisualTreeHelper.GetDescendantBounds(target).Y, width, height);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpiX, dpiY, PixelFormats.Pbgra32);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(target);
                ctx.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), bounds.Size));
            }
            rtb.Render(dv);
            return rtb;
        }
        public static System.Drawing.Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new System.Drawing.Bitmap(bitmap);
            }
        }
    }
}
