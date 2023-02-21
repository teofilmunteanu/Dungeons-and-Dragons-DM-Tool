using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            //_combatListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(CreatureViewModel.Initiative))
        //    {
        //        OnCanExecuteChanged();
        //    }
        //}

        public override bool CanExecute(object? parameter)
        {
            //bool HasInitiative = _combatantViewModel.Initiative >= 0 && !=null;
            return /*HasInitiative &&*/ base.CanExecute(parameter);
        }

        public async override void Execute(object? sender)
        {
            try
            {
                int creatureId = ((CreatureViewModel)sender).ID;
                double initiative = Convert.ToDouble(((CreatureViewModel)sender).Initiative);
                //double selectedCreatureInitiative = _combatListViewModel.SelectedCreature.Initiative;

                //_combatantsManager.GetCombatantById(creatureId).Initiative = initiative;
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
