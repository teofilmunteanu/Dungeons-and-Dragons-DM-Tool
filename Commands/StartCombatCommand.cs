using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System.Collections.Generic;

namespace Deez_Notes_Dm.Commands
{
    class StartCombatCommand : CommandBase
    {
        CombatSelectionViewModel _combatSelectionViewModel;
        CombatListViewModel _combatListViewModel;
        PlayersManager _playersManager;
        MonstersManager _monstersManager;
        CombatantsManager _combatantsManager;

        public StartCombatCommand(CombatSelectionViewModel combatSelectionViewModel, CombatListViewModel combatListViewModel, PlayersManager playersManager, MonstersManager monstersManager, CombatantsManager combatantsManager)
        {
            _combatSelectionViewModel = combatSelectionViewModel;
            _combatListViewModel = combatListViewModel;
            _playersManager = playersManager;
            _monstersManager = monstersManager;
            _combatantsManager = combatantsManager;
        }

        public async override void Execute(object? parameter)
        {
            _combatantsManager.Reset();

            foreach (Player player in _playersManager.GetPlayers())
            {
                _combatantsManager.AddCombatant(player);
            }

            List<Monster> monsters = await _monstersManager.GetMonstersForCombatAsync(_combatSelectionViewModel.SelectedCombatants);
            foreach (Monster monster in monsters)
            {
                _combatantsManager.AddCombatant(monster);
            }

            _combatListViewModel.UpdateCombatList();

            _combatSelectionViewModel.CancelCommand.Execute(null);
        }
    }
}
