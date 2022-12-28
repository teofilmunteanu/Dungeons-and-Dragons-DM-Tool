using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public PlayerListViewModel PlayersViewModel { get; }
        public NewPlayerFormViewModel PlayerFormViewModel { get; }


        private readonly NewPLayerFormStore _newPLayerFormStore;
        public bool IsModalOpen => _newPLayerFormStore.IsOpen;


        public MainViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            _newPLayerFormStore = newPLayerFormStore;

            PlayersViewModel = new PlayerListViewModel(playersManager, newPLayerFormStore);
            PlayerFormViewModel = new NewPlayerFormViewModel(PlayersViewModel, playersManager, newPLayerFormStore);

            _newPLayerFormStore.IsOpenChanged += OnIsModalOpenChanged;
        }

        private void OnIsModalOpenChanged()
        {
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
