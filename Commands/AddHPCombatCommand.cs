using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class AddHPCombatCommand : CommandBase
    {
        private readonly CreatureViewModel _combatantViewModel;
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;

        public AddHPCombatCommand(CreatureViewModel combatantViewModel, CombatListViewModel combatListViewModel, CombatantsManager combatantsManager)
        {
            _combatantViewModel = combatantViewModel;
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;

            _combatantViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatureViewModel.HP_Input))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasHP = !string.IsNullOrEmpty(_combatantViewModel.HP_Input);

            return HasHP && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                int hp = int.Parse(_combatantViewModel.HP_Input);

                _combatantsManager.HealCombatantWithId(_combatantViewModel.ID, hp);

                _combatListViewModel.UpdatePlayerAndCombatList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
