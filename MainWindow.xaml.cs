using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] XpById;

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

                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);
                PlayerList.ItemsSource = players;

                XpById = new int[players.Count + 1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetInputs()
        {
            this.NameInput.Text = "";
            this.RaceInput.Text = "";
            this.HPInput.Text = "";
            this.ACInput.Text = "";
            this.ClassInput.Text = "";

            this.STRInput.Text = "";
            this.DEXInput.Text = "";
            this.CONInput.Text = "";
            this.INTInput.Text = "";
            this.WISInput.Text = "";
            this.CHAInput.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NewPlayerForm.Visibility = Visibility.Visible;

            ResetInputs();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                String name = this.NameInput.Text;
                String race = this.RaceInput.Text;
                int HP = Int32.Parse(this.HPInput.Text);
                int AC = Int32.Parse(this.ACInput.Text);
                String _class = this.ClassInput.Text;
                //Dictionary<String, int> Stats = new Dictionary<String, int>
                //{
                //    {"STR", Int32.Parse(this.STRInput.Text)},
                //    {"DEX", Int32.Parse(this.DEXInput.Text)},
                //    {"CON", Int32.Parse(this.CONInput.Text)},
                //    {"INT", Int32.Parse(this.INTInput.Text)},
                //    {"WIS", Int32.Parse(this.WISInput.Text)},
                //    {"CHA", Int32.Parse(this.CHAInput.Text)}
                //};
                Player.Status stats = new Player.Status();
                stats.STR = Int32.Parse(this.STRInput.Text);
                stats.DEX = Int32.Parse(this.DEXInput.Text);
                stats.CON = Int32.Parse(this.CONInput.Text);
                stats.INT = Int32.Parse(this.INTInput.Text);
                stats.WIS = Int32.Parse(this.WISInput.Text);
                stats.CHA = Int32.Parse(this.CHAInput.Text);

                Player player = new Player(name, race, _class, HP, AC, stats);


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

            ResetInputs();
        }

        private void Button_Click_XPAdd(object sender, RoutedEventArgs e)
        {
            Player player = (Player)(sender as Button).DataContext;

            MessageBox.Show(player.ID + " " + XpById[player.ID]);
        }

        private void XPAddInput_TextChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Player player = (Player)(textBox.DataContext);

            if (textBox.Text == "")
            {
                XpById[player.ID] = 0;
            }
            else
            {
                try
                {
                    XpById[player.ID] = Int32.Parse(textBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void XPAddInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            //textBox.Text = "";
        }
    }
}
