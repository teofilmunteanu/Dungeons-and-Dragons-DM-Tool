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

                SetSelectedCreatureTypeCommand.Execute(null);
            }
        }


        private MonsterViewModel? selectedMonster = null;
        public MonsterViewModel? SelectedMonster
        {
            get => selectedMonster;
            set
            {
                SetField(ref selectedMonster, value);

                IsMonsterSelected = SelectedMonster != null ? true : false;
            }
        }

        private bool isMonsterSelected = false;
        public bool IsMonsterSelected
        {
            get => isMonsterSelected;
            set => SetField(ref isMonsterSelected, value);
        }


        private PlayerViewModel? selectedPlayer = null;
        public PlayerViewModel? SelectedPlayer
        {
            get => selectedPlayer;
            set
            {
                SetField(ref selectedPlayer, value);

                IsPlayerSelected = SelectedPlayer != null ? true : false;
            }
        }

        private bool isPlayerSelected = false;
        public bool IsPlayerSelected
        {
            get => isPlayerSelected;
            set => SetField(ref isPlayerSelected, value);
        }


        public ICommand ShowCombatSelectionCommand { get; }
        public ICommand SetSelectedCreatureTypeCommand { get; }
        public ICommand StopCombatCommand { get; }


        public CombatListViewModel(CombatantsManager combatantsManager, MonstersManager monstersManager, PlayersManager playersManager, CombatSelectionStore combatSelectionStore, PlayerListViewModel playerListViewModel)
        {
            _combatants = new ObservableCollection<CreatureViewModel>();

            _combatantsManager = combatantsManager;

            ShowCombatSelectionCommand = new ShowCombatSelectionCommand(combatSelectionStore);
            SetSelectedCreatureTypeCommand = new SetSelectedCombatantCommand(this, playerListViewModel, monstersManager, playersManager);
            StopCombatCommand = new StopCombatCommand(this, combatantsManager, playerListViewModel);

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
