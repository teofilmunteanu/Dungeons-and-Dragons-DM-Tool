using System.Windows.Controls;
using System.Windows.Input;

namespace Deez_Notes_Dm.Views
{
    /// <summary>
    /// Interaction logic for CombatSelectionView.xaml
    /// </summary>
    public partial class CombatSelectionView : UserControl
    {
        public CombatSelectionView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox selectedCombatantsList = this.FindName("SelectedCombatantsList") as ListBox;
            selectedCombatantsList.Items.Refresh();
        }

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem listBoxItem && listBoxItem.IsSelected)
            {
                listBoxItem.Dispatcher.InvokeAsync(() => listBoxItem.IsSelected = false);
            }
        }
    }
}
