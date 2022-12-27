using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.Commands
{
    public class ShowPlayerFormCommand : CommandBase
    {
        private readonly NewPLayerFormStore _newPLayerFormStore;

        public ShowPlayerFormCommand(NewPLayerFormStore newPLayerFormStore)
        {
            this._newPLayerFormStore = newPLayerFormStore;
        }

        public override void Execute(object? parameter)
        {
            _newPLayerFormStore.Open();
        }
    }
}
