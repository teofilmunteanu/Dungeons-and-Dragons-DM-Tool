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
            _newPlayerFormViewModel.HP = 0;
            _newPlayerFormViewModel.AC = 0;
            _newPlayerFormViewModel.MainClass = "";
            _newPlayerFormViewModel.Speed = 0;
            _newPlayerFormViewModel.FlySpeed = 0;

            _newPlayerFormViewModel.STR = 0;
            _newPlayerFormViewModel.DEX = 0;
            _newPlayerFormViewModel.CON = 0;
            _newPlayerFormViewModel.INT = 0;
            _newPlayerFormViewModel.WIS = 0;
            _newPlayerFormViewModel.CHA = 0;

            _newPlayerFormViewModel.InsightProficiency = false;
            _newPlayerFormViewModel.PerceptionProficiency = false;
            _newPlayerFormViewModel.InvestigationProficiency = false;
        }
    }
}
