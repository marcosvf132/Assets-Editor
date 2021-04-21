using Efundies;
using Google.Protobuf;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tibia.Protobuf.Appearances;
using Tibia.Protobuf.Shared;
using Tibia.Protobuf.StaticData;

namespace Assets_Editor
{
    public partial class Monsters : Window
    {
        private Monsterptr cacheData = new Monsterptr();
        public Monsters()
        {
            InitializeComponent();
            LoadCurrentMonsterData();
        }
        private void LoadCurrentMonsterData()
        {
            // Interface data boxes
            A_FlagLookType.IsChecked = true;
            A_FlagLookTypeEx.IsChecked = false;
            M_Addon.IsEnabled = true;
            M_LookTypeEx.IsEnabled = false;
            M_LookType.IsEnabled = true;
            M_LookHead_color.IsEnabled = true;
            M_LookBody_color.IsEnabled = true;
            M_LookLegs_color.IsEnabled = true;
            M_LookFeet_color.IsEnabled = true;

            // Monster list
            M_List.ItemsSource = null;
            M_List.ItemsSource = DatEditor.ThingsMonsters;

            // Values //
            M_Name.Text = "name";
            M_LookType.Value = 0;
            M_Addon.Value = 0;
            M_LookTypeEx.Value = 0;
            M_LookHead_color.Value = 0;
            M_LookBody_color.Value = 0;
            M_LookLegs_color.Value = 0;
            M_LookFeet_color.Value = 0;
            M_ID.Value = 1;

            /// Outfit 
            M_LookType_Outfit.Source = null;
            M_LookType_Addon.Source = null;
            M_LookType_Addon_Extended.Source = null;
        }
        public void OnPreviewKeyDown(object sender, KeyEventArgs args)
        {
            switch (args.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                case Key.D1:
                case Key.NumPad1:
                case Key.D2:
                case Key.NumPad2:
                case Key.D3:
                case Key.NumPad3:
                case Key.D4:
                case Key.NumPad4:
                case Key.D5:
                case Key.NumPad5:
                case Key.D6:
                case Key.NumPad6:
                case Key.D7:
                case Key.NumPad7:
                case Key.D8:
                case Key.NumPad8:
                case Key.D9:
                case Key.NumPad9:
                case Key.Return:
                case Key.Delete:
                    args.Handled = false;
                    break;
                default:
                    args.Handled = true;
                    break;
            }
        }
        private void M_ID_ValueChanged(object sender, RoutedEventArgs e)
        {
            M_ID.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            foreach (Monsterptr data_monster in DatEditor.ThingsMonsters)
            {
                if (data_monster.RaceId == M_ID.Value && data_monster != cacheData)
                {
                    M_ID.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                    break;
                }
            }
        }
        private void M_LookType_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (cacheData.LookTypeExBool)
            {
                A_FlagLookType.IsChecked = false;
                A_FlagLookTypeEx.IsChecked = true;
                M_LookTypeEx.IsEnabled = true;
                M_LookType.IsEnabled = false;
            }
            else
            {
                A_FlagLookType.IsChecked = true;
                A_FlagLookTypeEx.IsChecked = false;
                M_LookTypeEx.IsEnabled = false;
                M_LookType.IsEnabled = true;
            }


            M_LookType_Outfit.Source = null;
            M_LookType_Addon.Source = null;
            M_LookType_Addon_Extended.Source = null;
            if (M_LookType.Value != null && M_LookType.IsEnabled && (uint)M_LookType.Value > 0)
            {
                foreach (var outfit in MainWindow.appearances.Outfit)
                {
                    if (outfit.Id == (uint)M_LookType.Value)
                    {
                        /// Outfit
                        if (outfit.FrameGroup[0].SpriteInfo.SpriteId.Count > 4) /// Outfit with color template
                            M_LookType_Outfit.Source = Utils.BitmapColourizeSource(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[5]], MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[4]], (int)M_LookHead_color.Value, (int)M_LookBody_color.Value, (int)M_LookLegs_color.Value, (int)M_LookFeet_color.Value);
                        else if (outfit.FrameGroup[0].SpriteInfo.SpriteId.Count > 1) /// Regular monster outfit
                            M_LookType_Outfit.Source = Utils.BitmapToBitmapImage(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[2]]);
                        else /// Special idle outfits
                            M_LookType_Outfit.Source = Utils.BitmapToBitmapImage(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[0]]);

                        if (M_LookType_Outfit.Source == null)
                            M_LookType.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                        else
                            M_LookType.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));

                        /// Addon
                        if (outfit.FrameGroup[0].SpriteInfo.SpriteId.Count >= 21)
                        {
                            M_Addon.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
                            if (M_Addon.Value > 0)
                                if (M_Addon.Value < 3)
                                    M_LookType_Addon.Source = Utils.BitmapColourizeSource(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 1) * 8) + 13)]], MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 1) * 8) + 12)]], (int)M_LookHead_color.Value, (int)M_LookBody_color.Value, (int)M_LookLegs_color.Value, (int)M_LookFeet_color.Value);
                                else
                                {
                                    M_LookType_Addon.Source = Utils.BitmapColourizeSource(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 3) * 8) + 13)]], MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 3) * 8) + 12)]], (int)M_LookHead_color.Value, (int)M_LookBody_color.Value, (int)M_LookLegs_color.Value, (int)M_LookFeet_color.Value);
                                    M_LookType_Addon_Extended.Source = Utils.BitmapColourizeSource(MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 2) * 8) + 13)]], MainWindow.SprLists[(int)outfit.FrameGroup[0].SpriteInfo.SpriteId[(int)(((M_Addon.Value - 2) * 8) + 12)]], (int)M_LookHead_color.Value, (int)M_LookBody_color.Value, (int)M_LookLegs_color.Value, (int)M_LookFeet_color.Value);

                                }
                        }
                        else
                        {
                            M_Addon.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                        }
                        break;
                    }
                }
            } else if (M_LookTypeEx.Value != null && (uint)M_LookTypeEx.Value > 0)
            {
                foreach (var outfitEx in MainWindow.appearances.Object)
                {
                    if (outfitEx.Id == (uint)M_LookTypeEx.Value)
                    {
                        M_LookType_Outfit.Source = Utils.BitmapToBitmapImage(MainWindow.SprLists[(int)outfitEx.FrameGroup[0].SpriteInfo.SpriteId[0]]);
                        if (M_LookType_Outfit.Source == null)
                            M_LookTypeEx.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                        else
                            M_LookTypeEx.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
                        break;
                    }
                }

            }
        }
        private void M_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Monsterptr data_monster in DatEditor.ThingsMonsters)
            {
                if (data_monster.RaceId == cacheData.RaceId)
                {
                    DatEditor.ThingsMonsters.Remove(data_monster);
                    break;
                }
            }
            M_List.ItemsSource = null;
            M_List.ItemsSource = DatEditor.ThingsMonsters;
            StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' with id: {cacheData.RaceId} was removed");
        }

        private void M_New_Click(object sender, RoutedEventArgs e)
        {
            cacheData = new Monsterptr();
            M_Name.Text = "name";
            M_LookType.Value = 0;
            M_Addon.Value = 0;
            M_LookTypeEx.Value = 0;
            M_LookHead_color.Value = 0;
            M_LookBody_color.Value = 0;
            M_LookLegs_color.Value = 0;
            M_LookFeet_color.Value = 0;
            M_ID.Value = 1;
            M_LookType_ValueChanged(sender, e);
            StatusBar.MessageQueue.Enqueue("New creature template was created");
        }

        private void M_Save_Click(object sender, RoutedEventArgs e)
        {
            cacheData.Name = M_Name.Text;
            cacheData.LookType = (uint)M_LookType.Value;
            cacheData.LookTypeEx = (uint)M_LookTypeEx.Value;
            cacheData.LookTypeExBool = M_LookTypeEx.IsEnabled;
            cacheData.LookTypeBool = M_LookType.IsEnabled;
            cacheData.LookHead = (uint)M_LookHead_color.Value;
            cacheData.LookBody = (uint)M_LookBody_color.Value;
            cacheData.LookLegs = (uint)M_LookLegs_color.Value;
            cacheData.LookFeet = (uint)M_LookFeet_color.Value;
            cacheData.RaceId = (uint)M_ID.Value;
            cacheData.Addon = (uint)M_Addon.Value;
            bool overwrite = false;
            foreach (Monsterptr data_monster in DatEditor.ThingsMonsters)
            {
                if (data_monster.RaceId == cacheData.RaceId)
                {
                    DatEditor.ThingsMonsters.Remove(data_monster);
                    overwrite = true;
                    StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' overwrited the id: {cacheData.RaceId}");
                    break;
                }
            }
            DatEditor.ThingsMonsters.Add(cacheData);
            Utils.RegisterNewMonsterStaticData(cacheData);
            M_List.ItemsSource = null;
            M_List.ItemsSource = DatEditor.ThingsMonsters;
            if (!overwrite)
                StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' saved on id: {cacheData.RaceId}");
        }

        private void A_FlagLookType_Checked(object sender, RoutedEventArgs e)
        {
            A_FlagLookType.IsChecked = true;
            A_FlagLookTypeEx.IsChecked = false;
            M_Addon.IsEnabled = true;
            M_LookTypeEx.IsEnabled = false;
            M_LookType.IsEnabled = true;
            M_LookType_ValueChanged(sender, e);
            cacheData.LookTypeBool = true;
            cacheData.LookTypeExBool = false;
            M_LookHead_color.IsEnabled = true;
            M_LookBody_color.IsEnabled = true;
            M_LookLegs_color.IsEnabled = true;
            M_LookFeet_color.IsEnabled = true;
            M_Addon.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            M_LookTypeEx.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookHead_color.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            M_LookBody_color.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            M_LookLegs_color.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            M_LookFeet_color.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            StatusBar.MessageQueue.Enqueue("Looktype outfit selected");
        }

        private void A_FlagLookTypeEx_Checked(object sender, RoutedEventArgs e)
        {
            A_FlagLookType.IsChecked = false;
            A_FlagLookTypeEx.IsChecked = true;
            M_Addon.IsEnabled = false;
            M_LookTypeEx.IsEnabled = true;
            M_LookType.IsEnabled = false;
            M_LookHead_color.IsEnabled = false;
            M_LookBody_color.IsEnabled = false;
            M_LookLegs_color.IsEnabled = false;
            M_LookFeet_color.IsEnabled = false;
            cacheData.LookTypeBool = false;
            cacheData.LookTypeExBool = true;
            M_Addon.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookType.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookTypeEx.Foreground = new SolidColorBrush(color: Color.FromRgb(0, 0, 0));
            M_LookHead_color.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookBody_color.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookLegs_color.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookFeet_color.Foreground = new SolidColorBrush(color: Color.FromRgb(156, 156, 156));
            M_LookTypeEx_Preview.MessageQueue.Enqueue("ClientID only");
            M_LookType_ValueChanged(sender, e);
            StatusBar.MessageQueue.Enqueue("LooktypeEx item outfit selected");
        }

        private void M_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monsterptr ShowMonster = (Monsterptr)M_List.SelectedItem;
            if (ShowMonster != null)
            {
                cacheData = null;
                cacheData = ShowMonster;
                M_Name.Text = ShowMonster.Name;
                M_LookType.Value = (int?)ShowMonster.LookType;
                M_Addon.Value = (int?)ShowMonster.Addon;
                M_LookTypeEx.Value = (int?)ShowMonster.LookTypeEx;
                M_LookHead_color.Value = (int?)ShowMonster.LookHead;
                M_LookBody_color.Value = (int?)ShowMonster.LookBody;
                M_LookLegs_color.Value = (int?)ShowMonster.LookLegs;
                M_LookFeet_color.Value = (int?)ShowMonster.LookFeet;
                M_ID.Value = (int?)ShowMonster.RaceId;
                M_LookType_ValueChanged(sender, e);
            }
        }
    }
}
