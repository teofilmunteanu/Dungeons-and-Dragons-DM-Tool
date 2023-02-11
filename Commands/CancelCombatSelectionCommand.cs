using Deez_Notes_Dm.Stores;
using Deez_Notes_Dm.ViewModels;

namespace Deez_Notes_Dm.Commands
{
    public class CancelCombatSelectionCommand : CommandBase
    {
        private readonly CombatSelectionStore _combatSelectionStore;
        private readonly CombatSelectionViewModel _combatSelectionViewModel;

        public CancelCombatSelectionCommand(CombatSelectionViewModel combatSelectionViewModel, CombatSelectionStore combatSelectionStore)
        {
            _combatSelectionStore = combatSelectionStore;
            _combatSelectionViewModel = combatSelectionViewModel;
        }

        public override void Execute(object? parameter)
        {
            ResetInputs();
            _combatSelectionStore.Close();
        }

        private void ResetInputs()
        {
            _combatSelectionViewModel.SearchInput = "";

            if (_combatSelectionViewModel.FoundMonsters != null)
            {
                _combatSelectionViewModel.FoundMonsters.Clear();
            }
            if (_combatSelectionViewModel.SelectedCombatants != null)
            {
                _combatSelectionViewModel.SelectedCombatants.Clear();
            }
        }
    }
}
