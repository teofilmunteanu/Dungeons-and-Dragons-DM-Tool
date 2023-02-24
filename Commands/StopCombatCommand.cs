using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;

namespace Deez_Notes_Dm.Commands
{
    class StopCombatCommand : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;

        public StopCombatCommand(CombatListViewModel combatListViewModel, CombatantsManager combatantsManager)
        {
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;
        }

        public override void Execute(object? parameter)
        {
            _combatantsManager.Reset();

            _combatListViewModel.UpdateCombatList();
        }
    }
}
