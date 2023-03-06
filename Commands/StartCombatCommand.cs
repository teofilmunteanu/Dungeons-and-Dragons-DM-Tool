using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    class StartCombatCommand : CommandBase
    {
        private readonly CombatSelectionViewModel _combatSelectionViewModel;
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;
        private readonly MonstersManager _monstersManager;
        private readonly PlayersManager _playersManager;
        private readonly PlayerListViewModel _playerListViewModel;


        public StartCombatCommand(CombatSelectionViewModel combatSelectionViewModel, CombatListViewModel combatListViewModel, CombatantsManager combatantsManager,
            MonstersManager monstersManager, PlayersManager playersManager, PlayerListViewModel playerListViewModel)
        {
            _combatSelectionViewModel = combatSelectionViewModel;
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;
            _monstersManager = monstersManager;
            _playersManager = playersManager;
            _playerListViewModel = playerListViewModel;
        }

        public async override void Execute(object? parameter)
        {
            //TO DO: add only selected players (make separate player selection list)
            if (_combatListViewModel.Combatants.Count == 0)
            {
                foreach (Player player in _playersManager.GetPlayers())
                {
                    _combatantsManager.AddCombatant(player);
                }
            }

            try
            {
                foreach (string monsterName in _combatSelectionViewModel.SelectedMonsters)
                {
                    Monster monster = await _monstersManager.GetMonsterForCombatAsync(monsterName);
                    _combatantsManager.AddCombatant(monster);
                    _monstersManager.AddMonsterToCombat(monster);
                }

                _combatListViewModel.UpdateCombatList();

                _playerListViewModel.IsNotInCombat = false;
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    MessageBox.Show("Aborted; " + ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                _combatSelectionViewModel.CancelCommand.Execute(null);
            }
        }
    }
}
