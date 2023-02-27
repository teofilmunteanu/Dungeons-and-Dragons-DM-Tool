using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SortCombatListCommand : CommandBase
    {
        private readonly CombatListViewModel _combatListViewModel;
        private readonly CombatantsManager _combatantsManager;
        private readonly CreatureViewModel _creatureViewModel;

        public SortCombatListCommand(CreatureViewModel creatureViewModel, CombatListViewModel combatListViewModel, CombatantsManager combatantsManager)
        {
            _combatListViewModel = combatListViewModel;
            _combatantsManager = combatantsManager;
            _creatureViewModel = creatureViewModel;
        }


        public async override void Execute(object? sender)
        {
            try
            {
                int creatureId = _creatureViewModel.ID;
                double initiative = Convert.ToDouble(_creatureViewModel.Initiative);

                Creature creature = _combatantsManager.GetCombatantById(creatureId);
                creature.Initiative = initiative;

                _combatantsManager.SortByInitiative();
                _combatListViewModel.UpdateCombatList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
