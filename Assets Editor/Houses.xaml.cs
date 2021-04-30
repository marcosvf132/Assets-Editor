using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Google.Protobuf;
using Protobuf.Statichousedata;
using Tibia.Protobuf.Staticdata;
using House = Tibia.Protobuf.Staticdata.House;
using HousePosition = Tibia.Protobuf.Staticdata.HousePosition;

namespace Assets_Editor
{
    public partial class Houses : Window
    {
        private House cacheData = new House();
        private StaticHouseData houseData;
        public Houses()
        {
            InitializeComponent();
            InitHousementValues();
        }
        private void InitHousementValues()
        {
            HousePosition PositionTable = new HousePosition
            {
                PosX = 1000,
                PosY = 1000,
                PosZ = 7
            };
            cacheData.HousePosition = PositionTable;
            House_List.ItemsSource = null;
            House_Name_box.Text = "house name";
            House_City.Text = "city name";
            House_Id.Value = 1;
            House_Price.Value = 1;
            House_Beds.Value = 1;
            House_Size.Value = 1;
            House_Guildhall_Flag.IsChecked = false;
            House_Shop_Flag.IsChecked = false;
            House_Pos_x.Value = 1000;
            House_Pos_y.Value = 1000;
            House_Pos_z.Value = 7;
            House_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            House_List.ItemsSource = MainWindow.StaticData.House;
        }

        public void OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs args)
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

        private void House_ID_ValueChanged(object sender, RoutedEventArgs e)
        {
            House_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            foreach (House data_House in MainWindow.StaticData.House)
            {
                if (data_House.HouseId == House_Id.Value && data_House != cacheData)
                {
                    House_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                    break;
                }
            }
        }

        private void House_save_Click(object sender, RoutedEventArgs e)
        {
            House_List.ItemsSource = null;
            foreach (House data_House in MainWindow.StaticData.House)
            {
                if (data_House.HouseId == House_Id.Value)
                {
                    HousePosition PositionTable = new HousePosition
                    {
                        PosX = (uint)House_Pos_x.Value,
                        PosY = (uint)House_Pos_y.Value,
                        PosZ = (uint)House_Pos_z.Value
                    };
                    data_House.Name = House_Name_box.Text;
                    data_House.City = House_Name_box.Text;
                    data_House.Price = (uint)House_Price.Value;
                    data_House.Beds = (uint)House_Beds.Value;
                    data_House.Unknownstring = "";
                    data_House.HousePosition = PositionTable;
                    data_House.SizeSqm = (uint)House_Size.Value;
                    data_House.Guildhall = (bool)House_Guildhall_Flag.IsChecked;
                    data_House.Shop = (bool)House_Shop_Flag.IsChecked;
                    break;
                }
            }
            House_List.ItemsSource = MainWindow.StaticData.House;
        }

        private void House_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _housedata = new OpenFileDialog
            {
                Title = "Import house data info (.dat)",
                Filter = "dat files (*.dat)|*.dat",
                FilterIndex = 1,
                Multiselect = false
            };
            if (_housedata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(_housedata.FileName) == false)
                    return;

                houseData = StaticHouseData.Parser.ParseFrom(_housedata.OpenFile());
                if (houseData.Mapdata.Count() > 0 && houseData.House.Count() > 0)
                {
                    MainWindow.StaticData.House.Clear();
                    foreach (var houseImportPtr in houseData.House)
                    {
                        HousePosition tmpPos = new HousePosition
                        {
                            PosX = houseImportPtr.HousePosition.PosX,
                            PosY = houseImportPtr.HousePosition.PosY,
                            PosZ = houseImportPtr.HousePosition.PosZ
                        };
                        House tmpHouse = new House
                        {
                            HouseId = houseImportPtr.HouseId,
                            Name = houseImportPtr.Name,
                            Unknownstring = houseImportPtr.Unknownstring,
                            Price = houseImportPtr.Price,
                            Beds = houseImportPtr.Beds,
                            HousePosition = tmpPos,
                            SizeSqm = houseImportPtr.SizeSqm,
                            Guildhall = houseImportPtr.Guildhall,
                            City = houseImportPtr.City,
                            Shop = houseImportPtr.Shop
                        };
                        MainWindow.StaticData.House.Add(tmpHouse);
                    }
                    MainWindow.houseData = houseData;
                    InitHousementValues();
                }
                else
                    System.Windows.Forms.MessageBox.Show("You have selected a invalid house data package.");
            }
        }

        private void House_Export_Click(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog _housedata = new SaveFileDialog
            {
                Filter = "dat files (*.dat)|*.dat",
                Title = "Export house data info (.dat)",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (_housedata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = _housedata.OpenFile()) != null)
                {
                    MainWindow.houseData.WriteTo(myStream);
                    myStream.Close();
                }
            }
        }

        private void House_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            House ShowHouse = (House)House_List.SelectedItem;
            if (ShowHouse != null)
            {
                cacheData = ShowHouse;
                House_Name_box.Text = cacheData.Name;
                House_City.Text = cacheData.City;
                House_Id.Value = (int?)cacheData.HouseId;
                House_Price.Value = (int?)cacheData.Price;
                House_Beds.Value = (int?)cacheData.Beds;
                House_Size.Value = (int?)cacheData.SizeSqm;
                House_Guildhall_Flag.IsChecked = (bool)cacheData.Guildhall;
                House_Shop_Flag.IsChecked = (bool)cacheData.Shop;
                House_Pos_x.Value = (int?)cacheData.HousePosition.PosX;
                House_Pos_y.Value = (int?)cacheData.HousePosition.PosY;
                House_Pos_z.Value = (int?)cacheData.HousePosition.PosZ;
                House_ID_ValueChanged(null, null);
            }
        }
    }
}
