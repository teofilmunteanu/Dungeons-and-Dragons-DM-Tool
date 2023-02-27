using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerViewModel : CreatureViewModel
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
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


        public PlayerViewModel(Player player, PlayerListViewModel playerListViewModel, PlayersManager playersManager) : base(player.ID, player.Name, player.Race, player.HP, player.MaxHP, player.AC,
            player.Speeds, player.BaseStats, player.StatsMod, player.Initiative, player.Notes)
        {
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
        }
    }
}
