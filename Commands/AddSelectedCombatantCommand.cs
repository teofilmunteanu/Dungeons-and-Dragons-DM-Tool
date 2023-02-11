using Deez_Notes_Dm.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class AddSelectedCombatantCommand : CommandBase
    {
        private readonly CombatSelectionViewModel _combatSelectionViewModel;

        public AddSelectedCombatantCommand(CombatSelectionViewModel combatSelectionViewModel)
        {
            _combatSelectionViewModel = combatSelectionViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string selectedCombatant = _combatSelectionViewModel.SelectedItem;

                _combatSelectionViewModel.SelectedCombatants.Add(selectedCombatant);

                List<string> selectedCombatants = _combatSelectionViewModel.SelectedCombatants;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
