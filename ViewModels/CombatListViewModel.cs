using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class CombatListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CreatureViewModel> _combatants;
        private readonly CombatantsManager _combatantsManager;

        public ObservableCollection<CreatureViewModel> Combatants => _combatants;

        public ICommand ShowCombatSelectionCommand { get; }


        public CombatListViewModel(CombatantsManager combatantsManager, CombatSelectionStore combatSelectionStore)
        {
            _combatants = new ObservableCollection<CreatureViewModel>();

            ShowCombatSelectionCommand = new ShowCombatSelectionCommand(combatSelectionStore);

            _combatantsManager = combatantsManager;

            UpdateCombatList();
        }

        public void UpdateCombatList()
        {
            _combatants.Clear();
            List<Creature> combatantList = _combatantsManager.GetCombatants();

            if (combatantList != null)
            {
                foreach (Creature creature in combatantList)
                {
                    CreatureViewModel combatantViewModel = new CreatureViewModel(creature, this, _combatantsManager);
                    Combatants.Add(combatantViewModel);
                }
            }
        }
    }
}
