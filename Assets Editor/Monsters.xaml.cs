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
using Tibia.Protobuf.Staticdata;
using Colors = Tibia.Protobuf.Staticdata.Colors;

namespace Assets_Editor
{
    public partial class Monsters : Window
    {
        private Monster cacheData = CreateSampleCreature();

        /// <summary>
        ///  Colors:
        ///  InvalidCOlor: Red
        ///  ValidCOlor: Green
        ///  UnabledColor: Grey
        ///  EnabledColor: Black
        /// </summary>
        static private Color InvalidCOlor = Color.FromRgb(255, 0, 0);

        static private Color ValidCOlor = Color.FromRgb(26, 91, 0);

        static private Color UnabledColor = Color.FromRgb(156, 156, 156);

        static private Color EnabledColor = Color.FromRgb(0, 0, 0);
        public Monsters()
        {
            InitializeComponent();
            LoadCurrentMonsterData();
        }
        static private Monster CreateSampleCreature()
        {
            Monster sample = new Monster();
            Colors colorSample = new Colors
            {
                Lookhead = 95,
                Lookbody = 113,
                Looklegs = 39,
                Lookfeet = 115
            };
            Appearance_Type appereanceSample = new Appearance_Type
            {
                Outfittype = 129,
                Outfitaddon = 0,
                Colors = colorSample
            };
            sample.Raceid = 1;
            sample.Name = "sample";
            sample.AppearanceType = appereanceSample;

            return sample;
        }
        private void LoadCurrentMonsterData()
        {
            // Set first monster on the screen
            if (MainWindow.StaticData.Monster.First() != null)
            {
                cacheData = MainWindow.StaticData.Monster.First();
            }

            // Monster list
            M_List.ItemsSource = null;
            M_List.ItemsSource = MainWindow.StaticData.Monster;

            // Values //
            M_Name.Text = cacheData.Name;
            M_ID.Value = (int?)cacheData.Raceid;
            if (cacheData.AppearanceType.HasItemtype)
            {
                /// Enable LookTypeEx features
                M_LookTypeEx.IsEnabled = true;
                A_FlagLookTypeEx.IsChecked = true;
                M_LookTypeEx.Value = (int?)cacheData.AppearanceType.Itemtype;

                /// Disable LookType features
                M_Addon.IsEnabled = false;
                M_LookType.IsEnabled = false;
                A_FlagLookType.IsChecked = false;
                M_LookHead_color.IsEnabled = false;
                M_LookBody_color.IsEnabled = false;
                M_LookLegs_color.IsEnabled = false;
                M_LookFeet_color.IsEnabled = false;
            }
            else
            {
                /// Enable LookType features
                M_Addon.IsEnabled = true;
                M_LookType.IsEnabled = true;
                A_FlagLookType.IsChecked = true;
                M_LookHead_color.IsEnabled = true;
                M_LookBody_color.IsEnabled = true;
                M_LookLegs_color.IsEnabled = true;
                M_LookFeet_color.IsEnabled = true;
                M_LookType.Value = (int?)cacheData.AppearanceType.Outfittype;
                M_LookHead_color.Value = (int?)cacheData.AppearanceType.Colors.Lookhead;
                M_LookBody_color.Value = (int?)cacheData.AppearanceType.Colors.Lookbody;
                M_LookLegs_color.Value = (int?)cacheData.AppearanceType.Colors.Looklegs;
                M_LookFeet_color.Value = (int?)cacheData.AppearanceType.Colors.Lookfeet;
                M_Addon.Value = (int?)cacheData.AppearanceType.Outfitaddon;

                /// Disable LookTypeEx features
                A_FlagLookTypeEx.IsChecked = false;
                M_LookTypeEx.IsEnabled = false;
            }

            /// Outfit 
            M_LookType_Outfit.Source = null;
            M_LookType_Addon.Source = null;
            M_LookType_Addon_Extended.Source = null;
            M_LookType_ValueChanged(null, null);
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
            M_ID.Foreground = new SolidColorBrush(ValidCOlor);
            foreach (Monster data_monster in MainWindow.StaticData.Monster)
            {
                if (data_monster.Raceid == M_ID.Value && data_monster != cacheData)
                {
                    M_ID.Foreground = new SolidColorBrush(InvalidCOlor);
                    break;
                }
            }
        }
        private void M_LookType_ValueChanged(object sender, RoutedEventArgs e)
        {
            /// Ignore empty preview information
            if (cacheData.AppearanceType == null)
            {
                return;
            }

            /// Generate new images
            /// The outfits is created in different stages:
            /// [1]: Create the outfit base.
            ///       - Can be only the default outfit w/o addons.
            /// [2]: Create the first addon.
            ///       - Not realy addon="1" but only the first pallet.
            /// [3]: Create the second addons.
            ///       - This is only activated when the third addon value is selected.
            ///  -- The images is being colourized on their creation.
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
                            M_LookType.Foreground = new SolidColorBrush(InvalidCOlor);
                        else
                            M_LookType.Foreground = new SolidColorBrush(ValidCOlor);

                        /// Addon
                        if (outfit.FrameGroup[0].SpriteInfo.SpriteId.Count >= 21)
                        {
                            M_Addon.IsEnabled = true;
                            M_Addon.Foreground = new SolidColorBrush(ValidCOlor);
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
                            M_Addon.IsEnabled = false;
                            M_Addon.Foreground = new SolidColorBrush(InvalidCOlor);
                        }
                        break;
                    }
                }
            } else if (M_LookTypeEx.Value != null && M_LookTypeEx.IsEnabled && (uint)M_LookTypeEx.Value > 0)
            {
                foreach (var outfitEx in MainWindow.appearances.Object)
                {
                    if (outfitEx.Id == (uint)M_LookTypeEx.Value)
                    {
                        M_LookType_Outfit.Source = Utils.BitmapToBitmapImage(MainWindow.SprLists[(int)outfitEx.FrameGroup[0].SpriteInfo.SpriteId[0]]);
                        if (M_LookType_Outfit.Source == null)
                            M_LookTypeEx.Foreground = new SolidColorBrush(InvalidCOlor);
                        else
                            M_LookTypeEx.Foreground = new SolidColorBrush(ValidCOlor);
                        break;
                    }
                }

            }
        }
        private void M_Delete_Click(object sender, RoutedEventArgs e)
        {
            /// Remove if exist
            foreach (Monster data_monster in MainWindow.StaticData.Monster)
            {
                if (data_monster.Raceid == cacheData.Raceid)
                {
                    MainWindow.StaticData.Monster.Remove(data_monster);
                    M_List.ItemsSource = null;
                    M_List.ItemsSource = MainWindow.StaticData.Monster;
                    StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' id: {cacheData.Raceid} removed");
                    return;
                }
            }

            /// Send erroe message
            StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' is not registered");
        }

        private void M_New_Click(object sender, RoutedEventArgs e)
        {
            /// Create new window information
            cacheData = CreateSampleCreature();

            /// Update informations
            M_Name.Text = cacheData.Name;
            M_LookType.Value = (int?)cacheData.AppearanceType.Outfittype;
            M_Addon.Value = (int?)cacheData.AppearanceType.Outfitaddon;
            M_LookTypeEx.Value = 0;
            M_LookHead_color.Value = (int?)cacheData.AppearanceType.Colors.Lookhead;
            M_LookBody_color.Value = (int?)cacheData.AppearanceType.Colors.Lookbody;
            M_LookLegs_color.Value = (int?)cacheData.AppearanceType.Colors.Looklegs;
            M_LookFeet_color.Value = (int?)cacheData.AppearanceType.Colors.Lookfeet;
            M_ID.Value = (int?)cacheData.Raceid;

            /// Reload pewview
            M_LookType_ValueChanged(sender, e);

            /// Send message
            StatusBar.MessageQueue.Enqueue("New creature template was created");
        }

        private void M_Save_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)A_FlagLookTypeEx.IsChecked == (bool)A_FlagLookType.IsChecked)
            {
                StatusBar.MessageQueue.Enqueue($"Failed detecting outfit type on '{cacheData.Name}'");
                return;
            }
            cacheData.Name = M_Name.Text;
            cacheData.Raceid = (uint)M_ID.Value;
            if ((bool)A_FlagLookType.IsChecked)
            {
                cacheData.AppearanceType.ClearItemtype();
                Colors lookcolor = new Colors
                {
                    Lookhead = (uint)M_LookHead_color.Value,
                    Lookbody = (uint)M_LookBody_color.Value,
                    Looklegs = (uint)M_LookLegs_color.Value,
                    Lookfeet = (uint)M_LookFeet_color.Value
                };
                Appearance_Type childAppearance = new Appearance_Type
                {
                    Outfittype = (uint)M_LookType.Value,
                    Colors = lookcolor,
                    Outfitaddon = (uint)M_Addon.Value
                };
                cacheData.AppearanceType = childAppearance;
            }
            else
            {
                cacheData.AppearanceType.ClearOutfittype();
                cacheData.AppearanceType.ClearOutfitaddon();
                Appearance_Type childAppearance = new Appearance_Type
                {
                    Itemtype = (uint)M_LookTypeEx.Value
                };
                cacheData.AppearanceType = childAppearance;
            }
            bool overwrite = false;
            foreach (Monster data_monster in MainWindow.StaticData.Monster)
            {
                if (data_monster.Raceid == cacheData.Raceid)
                {
                    MainWindow.StaticData.Monster.Remove(data_monster);
                    overwrite = true;
                    StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' overwrited the id: {cacheData.Raceid}");
                    break;
                }
            }
            MainWindow.StaticData.Monster.Add(cacheData);
            Utils.RegisterNewMonsterStaticData(cacheData);
            M_List.ItemsSource = null;
            M_List.ItemsSource = MainWindow.StaticData.Monster;
            if (!overwrite)
                StatusBar.MessageQueue.Enqueue($"Creature '{cacheData.Name}' saved on id: {cacheData.Raceid}");
        }

        private void A_FlagLookType_Checked(object sender, RoutedEventArgs e)
        {
            /// Disactivate LookTypeEx features
            A_FlagLookTypeEx.IsChecked = false;
            M_LookTypeEx.IsEnabled = false;

            /// Activate LookType features
            M_LookType.IsEnabled = true;
            M_Addon.IsEnabled = true;
            M_LookHead_color.IsEnabled = true;
            M_LookBody_color.IsEnabled = true;
            M_LookLegs_color.IsEnabled = true;
            M_LookFeet_color.IsEnabled = true;

            /// Colors
            M_Addon.Foreground = new SolidColorBrush(EnabledColor);
            M_LookTypeEx.Foreground = new SolidColorBrush(UnabledColor);
            M_LookHead_color.Foreground = new SolidColorBrush(EnabledColor);
            M_LookBody_color.Foreground = new SolidColorBrush(EnabledColor);
            M_LookLegs_color.Foreground = new SolidColorBrush(EnabledColor);
            M_LookFeet_color.Foreground = new SolidColorBrush(EnabledColor);

            /// Reload preview
            M_LookType_ValueChanged(sender, e);

            /// Send Message
            StatusBar.MessageQueue.Enqueue("Looktype outfit selected");
        }

        private void A_FlagLookTypeEx_Checked(object sender, RoutedEventArgs e)
        {
            /// Disactivate LookType features
            A_FlagLookType.IsChecked = false;
            M_Addon.IsEnabled = false;
            M_LookType.IsEnabled = false;
            M_LookHead_color.IsEnabled = false;
            M_LookBody_color.IsEnabled = false;
            M_LookLegs_color.IsEnabled = false;
            M_LookFeet_color.IsEnabled = false;

            /// Activate LookTypeEx features
            M_LookTypeEx.IsEnabled = true;

            /// Colors
            M_Addon.Foreground = new SolidColorBrush(UnabledColor);
            M_LookType.Foreground = new SolidColorBrush(UnabledColor);
            M_LookTypeEx.Foreground = new SolidColorBrush(EnabledColor);
            M_LookHead_color.Foreground = new SolidColorBrush(UnabledColor);
            M_LookBody_color.Foreground = new SolidColorBrush(UnabledColor);
            M_LookLegs_color.Foreground = new SolidColorBrush(UnabledColor);
            M_LookFeet_color.Foreground = new SolidColorBrush(UnabledColor);

            /// Reload preview
            M_LookType_ValueChanged(sender, e);

            /// Messages
            M_LookTypeEx_Preview.MessageQueue.Enqueue("ClientID only");
            StatusBar.MessageQueue.Enqueue("LooktypeEx item outfit selected");
        }

        private void M_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monster ShowMonster = (Monster)M_List.SelectedItem;
            if (ShowMonster != null)
            {
                cacheData = null;
                cacheData = ShowMonster;
                M_Name.Text = ShowMonster.Name;
                if (ShowMonster.AppearanceType != null)
                {
                    M_LookType.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Outfittype : 0;
                    M_Addon.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Outfitaddon : 0;
                    M_LookTypeEx.Value = (bool)ShowMonster.AppearanceType.HasItemtype ? (int?)ShowMonster.AppearanceType.Itemtype : 0;
                    M_LookHead_color.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Colors.Lookhead : 0;
                    M_LookBody_color.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Colors.Lookbody : 0;
                    M_LookLegs_color.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Colors.Looklegs : 0;
                    M_LookFeet_color.Value = (bool)ShowMonster.AppearanceType.HasOutfittype ? (int?)ShowMonster.AppearanceType.Colors.Lookfeet : 0;
                }
                M_ID.Value = (int?)ShowMonster.Raceid;
                M_LookType_ValueChanged(sender, e);
            }
        }
    }
}
