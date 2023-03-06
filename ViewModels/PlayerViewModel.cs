using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        public int ID { get; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int MaxHP { get; set; }

        private int hp;
        public int HP
        {
            get => hp;
            set => SetField(ref hp, value);
        }

        public int AC { get; set; }

        public List<string> SpeedsList { get; set; }

        public Stats BaseStats { get; set; }

        public Stats StatsMod { get; set; }


        private string notes;
        public string Notes
        {
            get => notes;
            set
            {
                SetField(ref notes, value);

                if (UpdateNotesCommand != null)
                {
                    UpdateNotesCommand.Execute(null);
                }
            }
        }


        public string XP { get; set; }

        private string xpInput;
        public string XP_Input
        {
            get => xpInput;
            set => SetField(ref xpInput, value);
        }

        private string hpInput;
        public string HP_Input
        {
            get => hpInput;
            set => SetField(ref hpInput, value);
        }


        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; }


        public int HitDice { get; set; }


        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }


        public ICommand AddXPCommand { get; }

        public ICommand AddHPCommand { get; }
        public ICommand SubtractHPCommand { get; }


        public ICommand UpdateNotesCommand { get; }


        public PlayerViewModel(Player player, PlayerListViewModel playerListViewModel, PlayersManager playersManager)
        {
            ID = player.ID;
            Name = player.Name;
            Race = player.Race;
            HP = player.HP;
            MaxHP = player.MaxHP;
            AC = player.AC;
            if (player.Speeds is not null)
            {
                SpeedsList = CreatureViewModel.ToSpeedList(player.Speeds);
            }
            BaseStats = player.BaseStats;
            StatsMod = player.StatsMod;
            Notes = player.Notes;

            XP = player.XP + "";
            totalLevel = player.totalLevel;
            levelByClass = player.levelByClass;
            HitDice = player.HitDice;
            PassiveInsight = player.PassiveInsight;
            PassivePerception = player.PassivePerception;
            PassiveInvestigation = player.PassiveInvestigation;

            AddXPCommand = new AddXPCommand(this, playerListViewModel, playersManager);

            AddHPCommand = new AddHPCommand(this, playerListViewModel, playersManager);
            SubtractHPCommand = new SubtractHPCommand(this, playerListViewModel, playersManager);

            UpdateNotesCommand = new UpdatePlayerNotesCommand(this, playersManager);
        }

        //for setting SelectedPlayer in CombatListVM
        public PlayerViewModel(Player player, PlayersManager playersManager)
        {
            ID = player.ID;
            Name = player.Name;
            Race = player.Race;
            HP = player.HP;
            MaxHP = player.MaxHP;
            AC = player.AC;
            if (player.Speeds is not null)
            {
                SpeedsList = CreatureViewModel.ToSpeedList(player.Speeds);
            }
            BaseStats = player.BaseStats;
            StatsMod = player.StatsMod;
            Notes = player.Notes;

            XP = player.XP + "";
            totalLevel = player.totalLevel;
            levelByClass = player.levelByClass;
            HitDice = player.HitDice;
            PassiveInsight = player.PassiveInsight;
            PassivePerception = player.PassivePerception;
            PassiveInvestigation = player.PassiveInvestigation;

            UpdateNotesCommand = new UpdatePlayerNotesCommand(this, playersManager);
        }
    }
}
