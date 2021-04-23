using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tibia.Protobuf.Staticdata;

namespace Assets_Editor
{
    public partial class Houses : Window
    {
        private House cacheData = new House();
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
            HousePosition PositionTable = new HousePosition
            {
                PosX = (uint)House_Pos_x.Value,
                PosY = (uint)House_Pos_y.Value,
                PosZ = (uint)House_Pos_z.Value
            };
            cacheData.Name = House_Name_box.Text;
            cacheData.HouseId = (uint)House_Id.Value;
            cacheData.City = House_Name_box.Text;
            cacheData.Price = (uint)House_Price.Value;
            cacheData.Beds = (uint)House_Beds.Value;
            cacheData.Unknownstring = "";
            cacheData.HousePosition = PositionTable;
            cacheData.SizeSqm = (uint)House_Size.Value;
            cacheData.Guildhall = (bool)House_Guildhall_Flag.IsChecked;
            cacheData.Shop = (bool)House_Shop_Flag.IsChecked;
            House_List.ItemsSource = null;
            foreach (House data_House in MainWindow.StaticData.House)
            {
                if (data_House.HouseId == House_Id.Value)
                {
                    MainWindow.StaticData.House.Remove(data_House);
                    break;
                }
            }
            MainWindow.StaticData.House.Add(cacheData);
            House_List.ItemsSource = MainWindow.StaticData.House;
        }

        private void House_New_Click(object sender, RoutedEventArgs e)
        {
            cacheData = new House();
            InitHousementValues();
        }

        private void House_Delete_Click(object sender, RoutedEventArgs e)
        {

            House_List.ItemsSource = null;
            foreach (House data_House in MainWindow.StaticData.House)
            {
                if (data_House.HouseId == House_Id.Value)
                {
                    MainWindow.StaticData.House.Remove(data_House);
                    break;
                }
            }
            cacheData = new House();
            InitHousementValues();
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
