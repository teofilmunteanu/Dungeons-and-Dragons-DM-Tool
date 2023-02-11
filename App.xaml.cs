using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using Deez_Notes_Dm.ViewModels;
using System.Windows;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly PlayersManager _playersManager;
        private readonly MonstersManager _monstersManager;
        private readonly CombatantsManager _combatantsManager;


        private readonly NewPLayerFormStore _newPLayerFormStore;
        private readonly CombatSelectionStore _combatSelectionStore;

        public App()
        {
            _playersManager = new PlayersManager();
            _monstersManager = new MonstersManager(_playersManager);
            _newPLayerFormStore = new NewPLayerFormStore();

            _combatantsManager = new CombatantsManager(_playersManager);
            _combatSelectionStore = new CombatSelectionStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_playersManager, _newPLayerFormStore, _combatantsManager, _combatSelectionStore, _monstersManager)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
