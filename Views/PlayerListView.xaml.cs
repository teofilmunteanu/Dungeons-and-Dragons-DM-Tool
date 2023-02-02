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

        private void ButtonXP_LostFocus_HideInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.DeepSkyBlue);
            InputBtn.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
        }

        private void ButtonXP_Click_ShowInput(object sender, RoutedEventArgs e)
        {
            Button InputBtn = sender as Button;
            InputBtn.Background = new SolidColorBrush(Colors.White);
            InputBtn.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
