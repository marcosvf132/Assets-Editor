﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using MessageBox = System.Windows.Forms.MessageBox;
using Tibia.Protobuf.Appearances;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;
using System.ComponentModel;
using Tibia.Protobuf.Staticdata;
using Protobuf.Statichousedata;

namespace Assets_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static  string _assetsPath = "";
        public static string _datPath = "";
        public static string _staticPath = "";
        public static string _staticHousePath = "";
        /// <summary>
        ///  Statid Data
        /// </summary>
        public ushort QuestCount { get; set; }
        public ushort MonsterCount { get; set; }
        public ushort AchievCount { get; set; }
        public ushort BossCount { get; set; }
        
        /// <summary>
        ///  Appearances
        /// </summary>
        public ushort ObjectCount { get; set; }
        public ushort OutfitCount { get; set; }
        public ushort EffectCount { get; set; }
        public ushort MissileCount { get; set; }
        public ushort Version { get; set; }

        readonly BackgroundWorker worker = new BackgroundWorker();
        private int progress;
        public MainWindow()
        {
            InitializeComponent();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_Completed;
        }

        public class Catalog
        {
            public Catalog()
            {
                SpriteType = int.MinValue;
                FirstSpriteid = int.MinValue;
                LastSpriteid = int.MinValue;
                Area = int.MinValue;
                Version = int.MinValue;
            }
            public string Type { get; set; }
            public string File { get; set; }
            [DefaultValue(int.MinValue)]
            public int SpriteType { get; set; }
            [DefaultValue(int.MinValue)]
            public int FirstSpriteid { get; set; }
            [DefaultValue(int.MinValue)]
            public int LastSpriteid { get; set; }
            [DefaultValue(int.MinValue)]
            public int Area { get; set; }
            [DefaultValue(int.MinValue)]
            public int Version { get; set; }
        }
        
        public static List<Catalog> catalog;

        public static Appearances appearances;
        public static ObservableCollection<ShowList> AllSprList = new ObservableCollection<ShowList>();
        public static ConcurrentDictionary<int, MemoryStream> SprLists = new ConcurrentDictionary<int, MemoryStream>();
        public static int CustomSprLastId = 249999;

        public static StaticData StaticData;
        public static StaticHouseData houseData;
        public static ConcurrentDictionary<int, MemoryStream> HouseSprLists = new ConcurrentDictionary<int, MemoryStream>();

        private void LoadCatalogJson()
        {
            using StreamReader r = new StreamReader(_assetsPath + "catalog-content.json");
            string json = r.ReadToEnd();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            catalog = JsonConvert.DeserializeObject<List<Catalog>>(json, settings);
        }
        private void LoadAppearances()
        {
            _datPath = String.Format("{0}{1}", _assetsPath, catalog[0].File);
            if (File.Exists(_datPath) == false)
                return;
            FileStream appStream;
            using (appStream = new FileStream(_datPath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                appearances = Appearances.Parser.ParseFrom(appStream);
                ObjectCount = (ushort)appearances.Object.Count;
                OutfitCount = (ushort)appearances.Outfit.Count;
                EffectCount = (ushort)appearances.Effect.Count;
                MissileCount = (ushort)appearances.Missile.Count;

                ObjectsCount.Content = ObjectCount;
                OutfitsCount.Content = OutfitCount;
                EffectsCount.Content = EffectCount;
                MissilesCount.Content = MissileCount;
            }
        }
        private void LoadStaticData()
        {
            _staticPath = String.Format("{0}{1}", _assetsPath, catalog[1].File);
            if (File.Exists(_staticPath) == false)
                return;
            FileStream appStream;
            using (appStream = new FileStream(_staticPath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                StaticData = StaticData.Parser.ParseFrom(appStream);
                MonsterCount = (ushort)StaticData.Monster.Count;
                AchievCount = (ushort)StaticData.Achievements.Count;
                QuestCount = (ushort)StaticData.Quest.Count;
                BossCount = (ushort)StaticData.Boss.Count;
                MonstersCount.Content = MonsterCount;
                AchievsCount.Content = AchievCount;
                QuestsCount.Content = QuestCount;
                BossesCount.Content = BossCount;
            }
        }
        private void LoadStaticMapData()
        {
            _staticHousePath = String.Format("{0}{1}", _assetsPath, catalog[2].File);
            if (File.Exists(_staticHousePath) == false)
                return;
            FileStream appStream;
            using (appStream = new FileStream(_staticHousePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                houseData = StaticHouseData.Parser.ParseFrom(appStream);
            }

            houseData.House.Clear();
            foreach (var housePtr in StaticData.House)
            {
                Protobuf.Statichousedata.HousePosition tmpPos = new Protobuf.Statichousedata.HousePosition
                {
                    PosX = housePtr.HousePosition.PosX,
                    PosY = housePtr.HousePosition.PosY,
                    PosZ = housePtr.HousePosition.PosZ
                };
                Protobuf.Statichousedata.House tmpHouse = new Protobuf.Statichousedata.House
                {
                    HouseId = housePtr.HouseId,
                    Name = housePtr.Name,
                    Unknownstring = housePtr.Unknownstring,
                    Price = housePtr.Price,
                    Beds = housePtr.Beds,
                    HousePosition = tmpPos,
                    SizeSqm = housePtr.SizeSqm,
                    Guildhall = housePtr.Guildhall,
                    Shop = housePtr.Shop
                };
                houseData.House.Add(tmpHouse);
            }
        }

        private void SelectAssetsFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog _assets = new FolderBrowserDialog();
            if (_assets.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _assetsPath = _assets.SelectedPath;
                if (_assetsPath.EndsWith("\\") == false)
                    _assetsPath += "\\";
                AssetsPath.Text = _assetsPath;
            }
            if (_assetsPath != "" && File.Exists(_assetsPath + "catalog-content.json") == true)
            {

                LoadCatalogJson();
                LoadAppearances();
                LoadStaticData();
                LoadStaticMapData();
                LoadAssets.IsEnabled = true;
            }
            else
                MessageBox.Show("You have selected a wrong assets path.");
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadSprSheet();
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LoadProgress.Value = e.ProgressPercentage;
        }
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            DatEditor datEditor = new DatEditor(appearances);
            datEditor.Show();
            Hide();
        }
        private void LoadAssets_Click(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync();
            }
        }

        private void GenerateTileSetImageList(Bitmap bitmap, Catalog sheet)
        {
            using Bitmap tileSetImage = new Bitmap(bitmap);
            int tileCount = sheet.LastSpriteid - sheet.FirstSpriteid;
            int sprCount = 0;
            Image tile;

            if (sheet.SpriteType >= 0)
            {
                int xCols = (sheet.SpriteType == 0 || sheet.SpriteType == 1) ? 12 : 6;
                int yCols = (sheet.SpriteType == 0 || sheet.SpriteType == 2) ? 12 : 6;
                int tWidth = (sheet.SpriteType == 0 || sheet.SpriteType == 1) ? 32 : 64;
                int tHeight = (sheet.SpriteType == 0 || sheet.SpriteType == 2) ? 32 : 64;

                System.Drawing.Size tileSize = new System.Drawing.Size(tWidth, tHeight);
                for (int x = 0; x < yCols; x++)
                {
                    for (int y = 0; y < xCols; y++)
                    {
                        if (sprCount > tileCount)
                            break;

                        tile = new Bitmap(tileSize.Width, tileSize.Height, tileSetImage.PixelFormat);
                        Graphics g = Graphics.FromImage(tile);
                        Rectangle sourceRect = new Rectangle(y * tileSize.Width, x * tileSize.Height, tileSize.Width, tileSize.Height);
                        g.DrawImage(tileSetImage, new Rectangle(0, 0, tileSize.Width, tileSize.Height), sourceRect, GraphicsUnit.Pixel);
                        MemoryStream ms = new MemoryStream();
                        tile.Save(ms, ImageFormat.Png);
                        tile.Dispose();
                        SprLists[sheet.FirstSpriteid + sprCount] = ms;
                        g.Dispose();
                        sprCount++;
                    }
                }

            }
        }

        private void LoadSprSheet()
        {
            progress = 0;
            SprLists = new ConcurrentDictionary<int, MemoryStream>();
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount * 5
            };
            Parallel.ForEach(catalog, options, (spr, state) =>
            {
                if (spr.Type == "sprite")
                {
                    string _sprPath = String.Format("{0}{1}", _assetsPath, spr.File);
                    if (File.Exists(_sprPath))
                    {
                        Bitmap SheetM = LZMA.DecompressFileLZMA(_sprPath);
                        GenerateTileSetImageList(SheetM, spr);
                        SheetM.Dispose();
                    }

                }
                progress++;
                worker.ReportProgress((int)(progress * 100 / catalog.Count));
            });
            for (uint i = 0; i < catalog.Max(r => r.LastSpriteid) + 1; i++)
            {
                AllSprList.Add(new ShowList() { Id = i });
            }
        }
    }
}
