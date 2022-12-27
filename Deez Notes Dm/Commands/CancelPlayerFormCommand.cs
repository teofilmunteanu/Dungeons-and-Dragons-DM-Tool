using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.Commands
{
    public class CancelPlayerFormCommand : CommandBase
    {
        private readonly NewPLayerFormStore _newPLayerFormStore;

        public CancelPlayerFormCommand(NewPLayerFormStore newPLayerFormStore)
        {
            this._newPLayerFormStore = newPLayerFormStore;
        }

        public override void Execute(object? parameter)
        {
            _newPLayerFormStore.Close();
        }
    }
}
