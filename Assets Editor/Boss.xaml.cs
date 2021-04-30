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
    public partial class Bosses : Window
    {
        private Boss cacheData = new Boss();
        public Bosses()
        {
            InitializeComponent();
            InitBossmentValues();
        }
        private void InitBossmentValues()
        {
            Boss_List.ItemsSource = null;
            Boss_Id.Value = 1;
            Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Boss_Name_box.Text = "name";
            Boss_List.ItemsSource = MainWindow.StaticData.Boss;
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

        private void Boss_ID_ValueChanged(object sender, RoutedEventArgs e)
        {
            Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            foreach (Boss data_Boss in MainWindow.StaticData.Boss)
            {
                if (data_Boss.Id == Boss_Id.Value && data_Boss != cacheData)
                {
                    Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                    break;
                }
            }
        }

        private void Boss_save_Click(object sender, RoutedEventArgs e)
        {
            Boss_List.ItemsSource = null;
            cacheData.Name = Boss_Name_box.Text;
            cacheData.Id = (uint)Boss_Id.Value;
            foreach (Boss data_Boss in MainWindow.StaticData.Boss)
            {
                if (data_Boss.Id == Boss_Id.Value)
                {
                    MainWindow.StaticData.Boss.Remove(data_Boss);
                    break;
                }
            }
            MainWindow.StaticData.Boss.Add(cacheData);
            Boss_List.ItemsSource = MainWindow.StaticData.Boss;
        }

        private void Boss_New_Click(object sender, RoutedEventArgs e)
        {
            cacheData = new Boss();
            Boss_Id.Value = 1;
            Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Boss_Name_box.Text = "name";
        }

        private void Boss_Delete_Click(object sender, RoutedEventArgs e)
        {

            Boss_List.ItemsSource = null;
            foreach (Boss data_Boss in MainWindow.StaticData.Boss)
            {
                if (data_Boss.Id == Boss_Id.Value)
                {
                    MainWindow.StaticData.Boss.Remove(data_Boss);
                    break;
                }
            }
            cacheData = new Boss();
            Boss_Id.Value = 1;
            Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Boss_Name_box.Text = "name";
            Boss_List.ItemsSource = MainWindow.StaticData.Boss;
        }

        private void Boss_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boss ShowBoss = (Boss)Boss_List.SelectedItem;
            if (ShowBoss != null)
            {
                cacheData = ShowBoss;

                Boss_Id.Value = (int?)cacheData.Id;
                Boss_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
                Boss_Name_box.Text = cacheData.Name;
                Boss_ID_ValueChanged(null, null);
            }
        }
    }
}
