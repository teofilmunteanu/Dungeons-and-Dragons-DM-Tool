﻿using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class CombatListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CombatantViewModel> _combatants;
        private readonly CombatantsManager _combatantsManager;

        public ObservableCollection<CombatantViewModel> Combatants => _combatants;

        //public ICommand ShowPlayerFormCommand { get; }


        public CombatListViewModel(CombatantsManager combatantsManager/*, NewPLayerFormStore newPLayerFormStore*/)
        {
            _combatants = new ObservableCollection<CombatantViewModel>();

            //ShowPlayerFormCommand = new ShowPlayerFormCommand(newPLayerFormStore);

            _combatantsManager = combatantsManager;

            UpdateCombatList();
        }

        public void UpdateCombatList()
        {
            _combatants.Clear();
            List<Creature> combatantList = _combatantsManager.GetCombatants();

            if (combatantList != null)
            {
                foreach (Player player in combatantList)
                {
                    //CombatantViewModel combatantViewModel = new CombatantViewModel(player, this, _combatantsManager);
                    //Combatants.Add(combatantViewModel);
                }
            }
        }
    }
}
