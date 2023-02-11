using System.Windows.Controls;

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
    }
}
