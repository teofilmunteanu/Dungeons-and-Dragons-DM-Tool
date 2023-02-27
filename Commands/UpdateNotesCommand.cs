using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class UpdateNotesCommand : CommandBase
    {
        private readonly CreatureViewModel _combatantViewModel;
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;

        public UpdateNotesCommand(CreatureViewModel combatantViewModel, CombatListViewModel combatListViewModel, CombatantsManager combatantsManager)
        {
            _combatantViewModel = combatantViewModel;
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;
        }


        public override void Execute(object? parameter)
        {
            try
            {
                string notes = _combatantViewModel.Notes;

                _combatantsManager.UpdateNotesWith(_combatantViewModel.ID, notes);

                _combatListViewModel.UpdateCombatList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
