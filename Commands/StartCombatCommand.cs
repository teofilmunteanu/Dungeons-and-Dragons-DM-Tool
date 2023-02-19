﻿using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;

namespace Deez_Notes_Dm.Commands
{
    class StartCombatCommand : CommandBase
    {
        private readonly CombatSelectionViewModel _combatSelectionViewModel;
        private readonly CombatListViewModel _combatListViewModel;
        private readonly PlayersManager _playersManager;
        private readonly MonstersManager _monstersManager;
        private readonly CombatantsManager _combatantsManager;

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

            //TO DO: add only selected players (make separate player selection list)
            //foreach (Player player in _playersManager.GetPlayers())
            //{
            //    _combatantsManager.AddCombatant(player);
            //}

            foreach (string monsterName in _combatSelectionViewModel.SelectedMonsters)
            {
                Monster monster = await _monstersManager.GetMonsterForCombatAsync(monsterName);
                _combatantsManager.AddCombatant(monster);
                _monstersManager.AddMonsterToCombat(monster);
            }

            _combatListViewModel.UpdateCombatList();

            _combatSelectionViewModel.CancelCommand.Execute(null);
        }
    }
}