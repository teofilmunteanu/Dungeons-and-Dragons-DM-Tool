using Deez_Notes_Dm.Helper;
using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
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
        ObservableCollection<Player> players;

        public MainWindow()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser.Source = new Uri(String.Format("file:///{0}/Resources/DMSCreen.png", curDir));

            reinitializePlayers();
            reinitializeCombatants();
        }

        void reinitializePlayers()
        {
            try
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");
                players = JsonConvert.DeserializeObject<ObservableCollection<Player>>(json);

                //the count resets at every restart
                Player.PlayerCount = players.Count;
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

                System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);

                PlayerList.Items.Refresh();
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
            Player.PlayerCount = players.Count;
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
            this.SpeedInput.Text = "";
            this.FlySpeedInput.Text = "";

            this.STRInput.Text = "";
            this.DEXInput.Text = "";
            this.CONInput.Text = "";
            this.INTInput.Text = "";
            this.WISInput.Text = "";
            this.CHAInput.Text = "";

            this.InsightProfInput.IsChecked = false;
            this.PerceptionProfInput.IsChecked = false;
            this.InvestigationProfInput.IsChecked = false;
        }

        private void Button_Click_ShowPlayerForm(object sender, RoutedEventArgs e)
        {
            this.NewPlayerForm.Visibility = Visibility.Visible;

            ResetInputs();
        }

        private void Button_Click_CreatePlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                String name = this.NameInput.Text;
                String race = this.RaceInput.Text;
                int HP = Int32.Parse(this.HPInput.Text);
                int AC = Int32.Parse(this.ACInput.Text);
                String _class = this.ClassInput.Text;

                Speed speed = new()
                {
                    walk = Int32.Parse(this.SpeedInput.Text),
                    fly = this.FlySpeedInput.Text != "" ? Int32.Parse(this.FlySpeedInput.Text) : 0
                };

                bool insightProficiency = (bool)this.InsightProfInput.IsChecked;
                bool perceptionProficiency = (bool)this.PerceptionProfInput.IsChecked;
                bool investigationProficiency = (bool)this.InvestigationProfInput.IsChecked;

                Status stats = new()
                {
                    STR = Int32.Parse(this.STRInput.Text),
                    DEX = Int32.Parse(this.DEXInput.Text),
                    CON = Int32.Parse(this.CONInput.Text),
                    INT = Int32.Parse(this.INTInput.Text),
                    WIS = Int32.Parse(this.WISInput.Text),
                    CHA = Int32.Parse(this.CHAInput.Text)
                };


                Player player = new Player(name, race, _class, HP, AC, speed, stats,
                    insightProficiency, perceptionProficiency, investigationProficiency);

                addPlayer(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.NewPlayerForm.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_HidePlayerForm(object sender, RoutedEventArgs e)
        {
            this.NewPlayerForm.Visibility = Visibility.Collapsed;

            ResetInputs();
        }

        private void Button_Click_AddXP(object sender, RoutedEventArgs e)
        {
            Player player = (Player)(sender as Button).DataContext;

            players[player.ID].addXP(XpById[player.ID]);

            updatePlayers();
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

        private void Button_Click_ShowInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.White);
        }

        private void Button_LostFocus_HideInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.Black);
        }


        //Combat
        ObservableCollection<Creature> combatants;
        int[] HpById;

        void reinitializeCombatants()
        {
            try
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");

                //the count resets at every restart
                Player.PlayerCount = players.Count;

                combatants = new ObservableCollection<Creature>();

                foreach (Player player in players)
                {
                    combatants.Add((Creature)player);
                }

                HpById = new int[combatants.Count];

                CombatantsList.ItemsSource = combatants;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //!!!!!!!!!!!!!!!!!!!!!!! TO FINISH !!!!!!!!!!!!!!!!!!!!!!!!!!

        //private void Button_AddCombatant(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        //Monster monster = MonsterFetcher.GetMonster("goblin");

        //        //combatants.Add(monster);

        //        // !!!!!! ADD SEARCH BOX AND SELECT FROM JSON FOUND(ONLY SHOW THE MONSTER NAME)

        //        CombatantsList.Items.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private async void Button_AddCombatant(object sender, RoutedEventArgs e)
        {
            try
            {
                Monster monster = await MonsterFetcher.GetMonsterAsync("adult-red-dragon");
                monster.ID += combatants.Count;
                combatants.Add(monster);

                HpById = new int[combatants.Count];

                CombatantsList.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_SubtractHP(object sender, RoutedEventArgs e)
        {
            Creature creature = (Creature)(sender as Button).DataContext;

            combatants[creature.ID].dealDamage(HpById[creature.ID]);

            CombatantsList.Items.Refresh();

            updatePlayers();
        }

        private void HPModifyInput_TextChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Creature creature = (Creature)(textBox.DataContext);

            if (textBox.Text == "")
            {
                HpById[creature.ID] = 0;
            }
            else
            {
                try
                {
                    HpById[creature.ID] = Int32.Parse(textBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_AddHP(object sender, RoutedEventArgs e)
        {
            Creature creature = (Creature)(sender as Button).DataContext;

            combatants[creature.ID].heal(HpById[creature.ID]);

            CombatantsList.Items.Refresh();

            updatePlayers();
        }
    }
}
