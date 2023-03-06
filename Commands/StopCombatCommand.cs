using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;

namespace Deez_Notes_Dm.Commands
{
    class StopCombatCommand : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;
        private readonly PlayerListViewModel _playerListViewModel;


        public StopCombatCommand(CombatListViewModel combatListViewModel, CombatantsManager combatantsManager, PlayerListViewModel playerListViewModel)
        {
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;
            _playerListViewModel = playerListViewModel;
        }

        public override void Execute(object? parameter)
        {
            _combatantsManager.Reset();

            _combatListViewModel.UpdateCombatList();

            _playerListViewModel.IsNotInCombat = true;
        }
    }
}
