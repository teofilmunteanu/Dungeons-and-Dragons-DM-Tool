using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public PlayerListViewModel PlayerListVM { get; }
        public NewPlayerFormViewModel NewPlayerFormVM { get; }
        private readonly NewPLayerFormStore _newPLayerFormStore;
        public bool IsPlayerFormOpen => _newPLayerFormStore.IsOpen;


        public CombatListViewModel CombatListVM { get; }
        public CombatSelectionViewModel CombatSelectionVM { get; }
        private readonly CombatSelectionStore _combatSelectionStore;
        public bool IsCombatSelectionOpen => _combatSelectionStore.IsOpen;


        public MainViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore,
            CombatantsManager combatantsManager, CombatSelectionStore combatSelectionStore,
            MonstersManager monstersManager)
        {
            _newPLayerFormStore = newPLayerFormStore;
            _newPLayerFormStore.IsOpenChanged += OnIsModalOpenChanged;
            PlayerListVM = new PlayerListViewModel(playersManager, newPLayerFormStore);
            NewPlayerFormVM = new NewPlayerFormViewModel(PlayerListVM, playersManager, newPLayerFormStore);


            _combatSelectionStore = combatSelectionStore;
            _combatSelectionStore.IsOpenChanged += OnIsCombatSelectionOpenChanged;
            CombatListVM = new CombatListViewModel(combatantsManager, monstersManager, playersManager, combatSelectionStore, PlayerListVM);
            CombatSelectionVM = new CombatSelectionViewModel(CombatListVM, combatantsManager, combatSelectionStore, playersManager, monstersManager);
        }

        private void OnIsModalOpenChanged()
        {
            OnPropertyChanged(nameof(IsPlayerFormOpen));
        }

        private void OnIsCombatSelectionOpenChanged()
        {
            OnPropertyChanged(nameof(IsCombatSelectionOpen));
        }
    }
}
