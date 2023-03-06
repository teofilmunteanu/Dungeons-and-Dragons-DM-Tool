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
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly PlayersManager _playersManager;
        private readonly MonstersManager _monstersManager;
        private readonly CombatantsManager _combatantsManager;

        public StartCombatCommand(CombatSelectionViewModel combatSelectionViewModel, CombatListViewModel combatListViewModel/*, PlayerListViewModel playerListViewModel*/, PlayersManager playersManager, MonstersManager monstersManager, CombatantsManager combatantsManager)
        {
            _combatSelectionViewModel = combatSelectionViewModel;
            _combatListViewModel = combatListViewModel;
            //_playerListViewModel = playerListViewModel;
            _playersManager = playersManager;
            _monstersManager = monstersManager;
            _combatantsManager = combatantsManager;
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

                //add the actual viewModels from the list of players in the combatList for direct realtion between combat hp and player list hp, and others
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
