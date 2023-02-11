using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class CombatSelectionViewModel : ViewModelBase
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }


        private string searchInput;
        public string SearchInput
        {
            get
            {
                return searchInput;
            }
            set
            {
                searchInput = value;
                OnPropertyChanged(nameof(SearchInput));
                if (searchInput != "")
                {
                    SearchMonsterCommand.Execute(null);
                }
            }
        }

        List<string> foundMonsters;
        public List<string> FoundMonsters
        {
            get => foundMonsters;
            set => SetField(ref foundMonsters, value);
        }

        string selectedItem;
        public string SelectedItem
        {
            get => selectedItem;
            set
            {
                SetField(ref selectedItem, value);
                SelectedCombatants.Add(selectedItem);
            }
        }

        List<string> selectedCombatants;
        public List<string> SelectedCombatants
        {
            get => selectedCombatants;
            set => SetField(ref selectedCombatants, value);
        }

        public ICommand CancelCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand SearchMonsterCommand { get; }

        public CombatSelectionViewModel(CombatListViewModel combatListViewModel, CombatantsManager combatantsManager, CombatSelectionStore combatSelectionStore, PlayersManager playersManager, MonstersManager monstersManager)
        {
            selectedCombatants = new List<string>();

            CancelCommand = new CancelCombatSelectionCommand(this, combatSelectionStore);
            SearchMonsterCommand = new SearchMonsterCommand(this, monstersManager);
            StartCommand = new StartCombatCommand(this, combatListViewModel, playersManager, monstersManager, combatantsManager);
        }
    }
}
