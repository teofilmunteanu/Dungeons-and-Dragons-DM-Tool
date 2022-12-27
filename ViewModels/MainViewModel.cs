using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public PlayerListViewModel PlayersViewModel { get; }
        public NewPlayerFormViewModel PlayerFormViewModel { get; }


        private readonly NewPLayerFormStore _newPLayerFormStore;
        public bool IsModalOpen => _newPLayerFormStore.IsOpen;


        public MainViewModel(NewPLayerFormStore newPLayerFormStore)
        {
            _newPLayerFormStore = newPLayerFormStore;

            PlayersViewModel = new PlayerListViewModel(newPLayerFormStore);
            PlayerFormViewModel = new NewPlayerFormViewModel(newPLayerFormStore);

            _newPLayerFormStore.IsOpenChanged += OnIsModalOpenChanged;
        }

        private void OnIsModalOpenChanged()
        {
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
