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

        protected void SetSearchInput(string value)
        {
            searchInput = value;
            OnPropertyChanged(SearchInput);

            SearchMonsterCommand.Execute(null);
        }

        private string searchInput;
        public string SearchInput
        {
            get => searchInput;
            set => SetSearchInput(value);
        }

        List<string> foundMonsters;
        public List<string> FoundMonsters
        {
            get => foundMonsters;
            set => SetField(ref foundMonsters, value);
        }

        public ICommand CancelCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand SearchMonsterCommand { get; }

        public CombatSelectionViewModel(CombatListViewModel combatListViewModel, CombatantsManager combatantsManager, CombatSelectionStore combatSelectionStore, MonstersManager monstersManager)
        {
            CancelCommand = new CancelCombatSelectionCommand(this, combatSelectionStore);
            SearchMonsterCommand = new SearchMonsterCommand(this, monstersManager);
            //CreateCommand = new CreatePlayerCommand(this, playerListViewModel, playersManager);
        }
    }
}
