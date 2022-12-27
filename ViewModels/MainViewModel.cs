using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public NewPlayerFormViewModel PlayerFormViewModel { get; }


        private readonly NewPLayerFormStore _newPLayerFormStore;
        public bool IsModalOpen => _newPLayerFormStore.IsOpen;


        public MainViewModel(NewPLayerFormStore newPLayerFormStore)
        {
            _newPLayerFormStore = newPLayerFormStore;

            CurrentViewModel = new PlayerListViewModel();
            PlayerFormViewModel = new NewPlayerFormViewModel(newPLayerFormStore);

            _newPLayerFormStore.IsOpenChanged += OnIsModalOpenChanged;
        }

        private void OnIsModalOpenChanged()
        {
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
