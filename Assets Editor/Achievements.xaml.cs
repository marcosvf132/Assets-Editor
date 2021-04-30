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
    public partial class Achievements : Window
    {
        private Achievement cacheData = new Achievement();
        public Achievements()
        {
            InitializeComponent();
            InitAchievmentValues();
        }
        private void InitAchievmentValues()
        {
            Achiev_List.ItemsSource = null;
            Achiev_Id.Value = 1;
            Achiev_Grade.Value = 1;
            Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Achiev_Name_box.Text = "name";
            Achiev_Description_box.Text = "description";
            Achiev_List.ItemsSource = MainWindow.StaticData.Achievements;
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

        private void Achiev_ID_ValueChanged(object sender, RoutedEventArgs e)
        {
            Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            foreach (Achievement data_achiev in MainWindow.StaticData.Achievements)
            {
                if (data_achiev.AchievementId == Achiev_Id.Value && data_achiev != cacheData)
                {
                    Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                    break;
                }
            }
        }

        private void Achiev_save_Click(object sender, RoutedEventArgs e)
        {
            Achiev_List.ItemsSource = null;
            cacheData.Description = Achiev_Description_box.Text;
            cacheData.Name = Achiev_Name_box.Text;
            cacheData.AchievementId = (uint)Achiev_Id.Value;
            cacheData.Grade = (uint)Achiev_Grade.Value;
            foreach (Achievement data_achiev in MainWindow.StaticData.Achievements)
            {
                if (data_achiev.AchievementId == Achiev_Id.Value)
                {
                    MainWindow.StaticData.Achievements.Remove(data_achiev);
                    break;
                }
            }
            MainWindow.StaticData.Achievements.Add(cacheData);
            Achiev_List.ItemsSource = MainWindow.StaticData.Achievements;
        }

        private void Achiev_New_Click(object sender, RoutedEventArgs e)
        {
            cacheData = new Achievement();
            Achiev_Id.Value = 1;
            Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Achiev_Name_box.Text = "name";
            Achiev_Description_box.Text = "description";
            Achiev_Grade.Value = 1;
        }

        private void Achiev_Delete_Click(object sender, RoutedEventArgs e)
        {

            Achiev_List.ItemsSource = null;
            foreach (Achievement data_achiev in MainWindow.StaticData.Achievements)
            {
                if (data_achiev.AchievementId == Achiev_Id.Value)
                {
                    MainWindow.StaticData.Achievements.Remove(data_achiev);
                    break;
                }
            }
            cacheData = new Achievement();
            Achiev_Id.Value = 1;
            Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Achiev_Name_box.Text = "name";
            Achiev_Description_box.Text = "description";
            Achiev_Grade.Value = 1;
            Achiev_List.ItemsSource = MainWindow.StaticData.Achievements;
        }

        private void Achiev_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Achievement ShowAchiev = (Achievement)Achiev_List.SelectedItem;
            if (ShowAchiev != null)
            {
                cacheData = ShowAchiev;

                Achiev_Id.Value = (int?)cacheData.AchievementId;
                Achiev_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
                Achiev_Name_box.Text = cacheData.Name;
                Achiev_Description_box.Text = cacheData.Description;
                Achiev_Grade.Value = (int?)cacheData.Grade;
                Achiev_ID_ValueChanged(null, null);
            }
        }
    }
}
