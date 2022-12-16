using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] XpById;
        List<Player> players;//optional: ObservableCollection 

        public MainWindow()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser.Source = new Uri(String.Format("file:///{0}/Resources/DMSCreen.png", curDir));

            reinitializePlayers();
        }

        void reinitializePlayers()
        {
            try
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");
                players = JsonConvert.DeserializeObject<List<Player>>(json);

                //the count resets at every restart
                Player.setPlayerCount(players.Count);
                XpById = new int[players.Count];

                PlayerList.ItemsSource = players;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void updatePlayers()
        {
            try
            {
                String newJson = JsonConvert.SerializeObject(players);
                players = JsonConvert.DeserializeObject<List<Player>>(newJson); //wouldn't be needed if working with observableCol

                System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);

                PlayerList.ItemsSource = players;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void addPlayer(Player player)
        {
            players.Add(player);

            //the count resets at every restart
            Player.setPlayerCount(players.Count);
            XpById = new int[players.Count];

            updatePlayers();
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

                Player.Status stats = new Player.Status();
                stats.STR = Int32.Parse(this.STRInput.Text);
                stats.DEX = Int32.Parse(this.DEXInput.Text);
                stats.CON = Int32.Parse(this.CONInput.Text);
                stats.INT = Int32.Parse(this.INTInput.Text);
                stats.WIS = Int32.Parse(this.WISInput.Text);
                stats.CHA = Int32.Parse(this.CHAInput.Text);

                Player player = new Player(name, race, _class, HP, AC, stats);

                addPlayer(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

            players[player.ID].addXP(XpById[player.ID]);

            updatePlayers();

            //addxptextbox = "" - for the proper version (with propertyChanged events and so)
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
                    if (textBox.Text.Contains("/"))
                    {
                        int dividend = Int32.Parse(textBox.Text.Substring(0, textBox.Text.IndexOf("/")));
                        int divisor;

                        if (textBox.Text.IndexOf("/") == textBox.Text.Length - 1)
                        {
                            divisor = 1;
                        }
                        else
                        {
                            divisor = Int32.Parse(textBox.Text.Substring(textBox.Text.IndexOf("/") + 1, textBox.Text.Length - textBox.Text.IndexOf("/") - 1));
                        }

                        XpById[player.ID] = dividend / divisor;
                    }
                    else
                    {
                        XpById[player.ID] = Int32.Parse(textBox.Text);
                    }
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

        private void Button_Click_ShowXP(object sender, RoutedEventArgs e)
        {
            Button XPBtn = sender as Button;
            XPBtn.Background = new SolidColorBrush(Colors.White);
        }

        private void Button_LostFocus_HideXP(object sender, RoutedEventArgs e)
        {
            Button XPBtn = sender as Button;
            XPBtn.Background = new SolidColorBrush(Colors.Black);
        }
    }
}
