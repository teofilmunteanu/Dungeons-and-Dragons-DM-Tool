using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public PlayerListViewModel PlayerListVM { get; }
        public NewPlayerFormViewModel NewPlayerFormVM { get; }
        public CombatListViewModel CombatVM { get; }

        private readonly NewPLayerFormStore _newPLayerFormStore;
        public bool IsPlayerFormOpen => _newPLayerFormStore.IsOpen;

        public MainViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            _newPLayerFormStore = newPLayerFormStore;

            PlayerListVM = new PlayerListViewModel(playersManager, newPLayerFormStore);
            NewPlayerFormVM = new NewPlayerFormViewModel(PlayerListVM, playersManager, newPLayerFormStore);

            _newPLayerFormStore.IsOpenChanged += OnIsModalOpenChanged;


            //CombatVM = new CombatViewModel(playersManager, newPLayerFormStore, PlayerListVM);
        }

        private void OnIsModalOpenChanged()
        {
            OnPropertyChanged(nameof(IsPlayerFormOpen));
        }
    }
}
