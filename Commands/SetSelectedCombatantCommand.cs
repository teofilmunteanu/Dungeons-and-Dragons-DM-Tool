using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Linq;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SetSelectedCombatantCommand : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly MonstersManager _monstersManager;

        public SetSelectedCombatantCommand(CombatListViewModel combatListViewModel, PlayerListViewModel playerListViewModel, MonstersManager monstersManager, PlayersManager playersManager)
        {
            _combatListViewModel = combatListViewModel;
            _playerListViewModel = playerListViewModel;
            _monstersManager = monstersManager;
        }

        public async override void Execute(object? parameter)
        {
            try
            {
                if (_combatListViewModel.SelectedCreature != null)
                {
                    if (_monstersManager.IsCombatantMonster(_combatListViewModel.SelectedCreature.ID))
                    {
                        Monster monster = _monstersManager.GetCombatMonsterById(_combatListViewModel.SelectedCreature.ID);
                        _combatListViewModel.SelectedMonster = new MonsterViewModel(monster, _monstersManager);

                        _combatListViewModel.SelectedPlayer = null;
                    }
                    else
                    {
                        //getting the actual playerVM so the properties are connected between tabs
                        _combatListViewModel.SelectedPlayer = _playerListViewModel.Players.Where(p => p.ID == _combatListViewModel.SelectedCreature.ID).First();

                        _combatListViewModel.SelectedMonster = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
