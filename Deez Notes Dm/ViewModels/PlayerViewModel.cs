using Deez_Notes_Dm.Models;
using System.Collections.Generic;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerViewModel : CreatureViewModel
    {
        public int XP { get; set; }
        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; }


        public int HitDice { get; set; }
        public (int successes, int fails) DeathSaves { get; set; }


        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }


        public PlayerViewModel(Player player) : base(player.ID, player.Name, player.Race, player.MaxHP, player.AC,
            player.SpeedsList, player.BaseStats, player.StatsMod)
        {
            XP = player.XP;
            totalLevel = player.totalLevel;
            levelByClass = player.levelByClass;
            HitDice = player.HitDice;
            DeathSaves = player.DeathSaves;
            PassiveInsight = player.PassiveInsight;
            PassivePerception = player.PassivePerception;
            PassiveInvestigation = player.PassiveInvestigation;
        }
    }
}
