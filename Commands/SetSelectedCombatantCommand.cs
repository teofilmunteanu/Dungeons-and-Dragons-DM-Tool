using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SetSelectedCombatantCommand : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly MonstersManager _monstersManager;

        public SetSelectedCombatantCommand(CombatListViewModel combatListViewModel, MonstersManager monstersManager)
        {
            _combatListViewModel = combatListViewModel;
            _monstersManager = monstersManager;

            _combatListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.HP_Input))
            {
                OnCanExecuteChanged();
            }
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
                    }
                    else
                    {
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
