using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class CombatListViewModel : ViewModelBase
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        private readonly ObservableCollection<CreatureViewModel> _combatants;
        private readonly CombatantsManager _combatantsManager;

        public ObservableCollection<CreatureViewModel> Combatants => _combatants;


        CreatureViewModel selectedCreature;
        public CreatureViewModel SelectedCreature
        {
            get => selectedCreature;
            set
            {
                SetField(ref selectedCreature, value);

                SetSelectedMonsterCommand.Execute(null);
            }
        }

        private MonsterViewModel? selectedMonster = null;
        public MonsterViewModel? SelectedMonster
        {
            get => selectedMonster;
            set => SetField(ref selectedMonster, value);
        }


        public ICommand ShowCombatSelectionCommand { get; }
        public ICommand SetSelectedMonsterCommand { get; }


        public CombatListViewModel(CombatantsManager combatantsManager, MonstersManager monstersManager, CombatSelectionStore combatSelectionStore)
        {
            _combatants = new ObservableCollection<CreatureViewModel>();

            _combatantsManager = combatantsManager;

            ShowCombatSelectionCommand = new ShowCombatSelectionCommand(combatSelectionStore);
            SetSelectedMonsterCommand = new SetSelectedCombatMonster(this, monstersManager);

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
