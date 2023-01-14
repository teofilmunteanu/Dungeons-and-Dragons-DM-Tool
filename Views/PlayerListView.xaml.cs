using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Deez_Notes_Dm.Views
{
    /// <summary>
    /// Interaction logic for PlayerListView.xaml
    /// </summary>
    public partial class PlayerListView : UserControl
    {
        public PlayerListView()
        {
            InitializeComponent();
        }

        //void updatePlayers()
        //{
        //    try
        //    {
        //        String newJson = JsonConvert.SerializeObject(players);

        //        System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);

        //        PlayerList.Items.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //public void addPlayer(Player player)
        //{
        //    players.Add(player);

        //    //the count resets at every restart
        //    //Player.PlayerCount = players.Count;
        //    XpById = new int[players.Count];

        //    updatePlayers();
        //}

        //private void Button_Click_AddXP(object sender, RoutedEventArgs e)
        //{
        //    Player player = (Player)(sender as Button).DataContext;

        //    players[player.ID].addXP(XpById[player.ID]);

        //    updatePlayers();
        //}

        //private void XPAddInput_TextChanged(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    Player player = (Player)(textBox.DataContext);

        //    if (textBox.Text == "")
        //    {
        //        XpById[player.ID] = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            if (textBox.Text.Contains("/"))
        //            {
        //                int dividend = Int32.Parse(textBox.Text.Substring(0, textBox.Text.IndexOf("/")));
        //                int divisor;

        //                if (textBox.Text.IndexOf("/") == textBox.Text.Length - 1)
        //                {
        //                    divisor = 1;
        //                }
        //                else
        //                {
        //                    divisor = Int32.Parse(textBox.Text.Substring(textBox.Text.IndexOf("/") + 1, textBox.Text.Length - textBox.Text.IndexOf("/") - 1));
        //                }

        //                XpById[player.ID] = dividend / divisor;
        //            }
        //            else
        //            {
        //                XpById[player.ID] = Int32.Parse(textBox.Text);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void HPModifyInput_TextChanged(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    Creature creature = (Creature)(textBox.DataContext);

        //    if (textBox.Text == "")
        //    {
        //        HpById[creature.ID] = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            HpById[creature.ID] = Int32.Parse(textBox.Text);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void Button_Click_SubtractHP(object sender, RoutedEventArgs e)
        //{
        //    Player player = (Player)(sender as Button).DataContext;

        //    players[player.ID].dealDamage(HpById[player.ID]);

        //    CombatantsList.Items.Refresh();

        //    updatePlayers();
        //}

        //private void Button_Click_AddHP(object sender, RoutedEventArgs e)
        //{
        //    Player player = (Player)(sender as Button).DataContext;

        //    players[player.ID].heal(HpById[player.ID]);

        //    CombatantsList.Items.Refresh();

        //    updatePlayers();
        //}

        private void ButtonXP_LostFocus_HideInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.DeepSkyBlue);
            InputBtn.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
        }

        private void Button_Click_ShowInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.White);
            InputBtn.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
