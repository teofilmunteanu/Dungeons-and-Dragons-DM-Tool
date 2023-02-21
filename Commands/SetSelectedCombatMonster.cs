using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SetSelectedCombatMonster : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly MonstersManager _monstersManager;

        public SetSelectedCombatMonster(CombatListViewModel combatListViewModel, MonstersManager monstersManager)
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

        public override bool CanExecute(object? parameter)
        {
            bool IsMonster = _combatListViewModel.SelectedCreature != null && _monstersManager.IsCombatantMonster(_combatListViewModel.SelectedCreature.ID);
            return IsMonster && base.CanExecute(parameter);
        }

        public async override void Execute(object? parameter)
        {
            try
            {
                if (_combatListViewModel.SelectedCreature != null)
                {
                    Monster monster = _monstersManager.GetCombatMonsterById(_combatListViewModel.SelectedCreature.ID);// await _monstersManager.GetMonsterForCombatAsync(_combatListViewModel.SelectedCreature.Name);
                    _combatListViewModel.SelectedMonster = new MonsterViewModel(monster);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
