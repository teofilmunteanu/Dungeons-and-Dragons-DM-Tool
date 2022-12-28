using Deez_Notes_Dm.Stores;
using Deez_Notes_Dm.ViewModels;

namespace Deez_Notes_Dm.Commands
{
    public class CancelPlayerFormCommand : CommandBase
    {
        private readonly NewPLayerFormStore _newPLayerFormStore;
        private readonly NewPlayerFormViewModel _newPlayerFormViewModel;

        public CancelPlayerFormCommand(NewPlayerFormViewModel newPlayerFormViewModel, NewPLayerFormStore newPLayerFormStore)
        {
            _newPLayerFormStore = newPLayerFormStore;
            _newPlayerFormViewModel = newPlayerFormViewModel;
        }

        public override void Execute(object? parameter)
        {
            ResetInputs();
            _newPLayerFormStore.Close();
        }

        private void ResetInputs()
        {
            _newPlayerFormViewModel.Name = "";
            _newPlayerFormViewModel.Race = "";
            _newPlayerFormViewModel.HP = "";
            _newPlayerFormViewModel.AC = "";
            _newPlayerFormViewModel.MainClass = "";
            _newPlayerFormViewModel.Speed = "";
            _newPlayerFormViewModel.FlySpeed = "";

            _newPlayerFormViewModel.STR = "";
            _newPlayerFormViewModel.DEX = "";
            _newPlayerFormViewModel.CON = "";
            _newPlayerFormViewModel.INT = "";
            _newPlayerFormViewModel.WIS = "";
            _newPlayerFormViewModel.CHA = "";

            _newPlayerFormViewModel.InsightProficiency = false;
            _newPlayerFormViewModel.PerceptionProficiency = false;
            _newPlayerFormViewModel.InvestigationProficiency = false;
        }
    }
}
