using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Stores;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class NewPlayerFormViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public NewPlayerFormViewModel(NewPLayerFormStore newPLayerFormStore)
        {
            CancelCommand = new CancelPlayerFormCommand(newPLayerFormStore);
            SubmitCommand = new CreatePlayerCommand();
        }
    }
}
