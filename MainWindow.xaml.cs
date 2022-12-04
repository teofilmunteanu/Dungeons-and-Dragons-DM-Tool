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

                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");


                PlayerList.ItemsSource = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NewPlayerForm.Visibility = Visibility.Visible;

            this.NameInput.Text = "";
            this.RaceInput.Text = "";
            this.HPInput.Text = "";
            this.ACInput.Text = "";

            this.STRInput.Text = "";
            this.DEXInput.Text = "";
            this.CONInput.Text = "";
            this.INTInput.Text = "";
            this.WISInput.Text = "";
            this.CHAInput.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                String Name = this.NameInput.Text;
                String Race = this.RaceInput.Text;
                int HP = Int32.Parse(this.HPInput.Text);
                int AC = Int32.Parse(this.ACInput.Text);
                Dictionary<String, int> Stats = new Dictionary<String, int>
                {
                    {"STR", Int32.Parse(this.STRInput.Text)},
                    {"DEX", Int32.Parse(this.DEXInput.Text)},
                    {"CON", Int32.Parse(this.CONInput.Text)},
                    {"INT", Int32.Parse(this.INTInput.Text)},
                    {"WIS", Int32.Parse(this.WISInput.Text)},
                    {"CHA", Int32.Parse(this.CHAInput.Text)}
                };

                Player player = new Player(Name, Race, HP, AC, Stats);

                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");
                string newJson;

                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);
                players.Add(player);
                newJson = JsonConvert.SerializeObject(players);

                System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            OutputJson();

            this.NewPlayerForm.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NewPlayerForm.Visibility = Visibility.Collapsed;

            this.NameInput.Text = "";
            this.RaceInput.Text = "";
            this.HPInput.Text = "";
            this.ACInput.Text = "";

            this.STRInput.Text = "";
            this.DEXInput.Text = "";
            this.CONInput.Text = "";
            this.INTInput.Text = "";
            this.WISInput.Text = "";
            this.CHAInput.Text = "";
        }
    }
}
