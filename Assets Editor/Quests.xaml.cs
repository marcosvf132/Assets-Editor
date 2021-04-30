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
    public partial class Quests : Window
    {
        private Quest cacheData = new Quest();
        public Quests()
        {
            InitializeComponent();
            InitQuestmentValues();
        }
        private void InitQuestmentValues()
        {
            Quest_List.ItemsSource = null;
            Quest_Id.Value = 1;
            Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Quest_Name_box.Text = "name";
            Quest_List.ItemsSource = MainWindow.StaticData.Quest;
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

        private void Quest_ID_ValueChanged(object sender, RoutedEventArgs e)
        {
            Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            foreach (Quest data_Quest in MainWindow.StaticData.Quest)
            {
                if (data_Quest.Id == Quest_Id.Value && data_Quest != cacheData)
                {
                    Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(255, 0, 0));
                    break;
                }
            }
        }

        private void Quest_save_Click(object sender, RoutedEventArgs e)
        {
            Quest_List.ItemsSource = null;
            cacheData.Name = Quest_Name_box.Text;
            cacheData.Id = (uint)Quest_Id.Value;
            foreach (Quest data_Quest in MainWindow.StaticData.Quest)
            {
                if (data_Quest.Id == Quest_Id.Value)
                {
                    MainWindow.StaticData.Quest.Remove(data_Quest);
                    break;
                }
            }
            MainWindow.StaticData.Quest.Add(cacheData);
            Quest_List.ItemsSource = MainWindow.StaticData.Quest;
        }

        private void Quest_New_Click(object sender, RoutedEventArgs e)
        {
            cacheData = new Quest();
            Quest_Id.Value = 1;
            Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Quest_Name_box.Text = "name";
        }

        private void Quest_Delete_Click(object sender, RoutedEventArgs e)
        {

            Quest_List.ItemsSource = null;
            foreach (Quest data_Quest in MainWindow.StaticData.Quest)
            {
                if (data_Quest.Id == Quest_Id.Value)
                {
                    MainWindow.StaticData.Quest.Remove(data_Quest);
                    break;
                }
            }
            cacheData = new Quest();
            Quest_Id.Value = 1;
            Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
            Quest_Name_box.Text = "name";
            Quest_List.ItemsSource = MainWindow.StaticData.Quest;
        }

        private void Quest_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Quest ShowQuest = (Quest)Quest_List.SelectedItem;
            if (ShowQuest != null)
            {
                cacheData = ShowQuest;

                Quest_Id.Value = (int?)cacheData.Id;
                Quest_Id.Foreground = new SolidColorBrush(color: Color.FromRgb(26, 91, 0));
                Quest_Name_box.Text = cacheData.Name;
                Quest_ID_ValueChanged(null, null);
            }
        }
    }
}
