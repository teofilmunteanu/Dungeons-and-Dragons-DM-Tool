using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser.Source = new Uri(String.Format("file:///{0}/Resources/DMSCreen.png", curDir));

            OutputJson();
        }

        public void OutputJson()
        {
            try
            {

                string json = System.IO.File.ReadAllText(@"Resources/Players/Test.json");


                PlayerList.ItemsSource = JsonConvert.DeserializeObject<List<Test>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
