using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Models
{

    public class Player : Creature
    {
        static readonly int[] XPbyLevel = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        public int XP { get; set; }
        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; } = new SortedDictionary<string, int>();


        public int HitDice { get; set; }


        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }

        private static readonly int[] proficiencyByLevel = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };

        private bool proficiencyInsight;
        private bool proficiencyInvestigation;
        private bool proficiencyPerception;

        public Player()
        {

        }

        //for creator
        public Player(int id, string name, string race, int maxHP, int ac, Speed speed, Stats stats,
            string _class, bool proficiency_insight, bool proficiency_perception, bool proficiency_investigation) : base(id, name, race, maxHP, ac, speed, stats)
        {
            XP = 0;
            totalLevel = 1;
            levelByClass.Add(_class, 1);

            HitDice = 1;

            proficiencyInsight = proficiency_insight;
            proficiencyPerception = proficiency_perception;
            proficiencyInvestigation = proficiency_investigation;

            PassiveInsight = getPassiveStat(StatsMod.WIS, proficiencyInsight);
            PassivePerception = getPassiveStat(StatsMod.WIS, proficiencyPerception);
            PassiveInvestigation = getPassiveStat(StatsMod.INT, proficiencyInvestigation);
        }

        //for provider
        public Player(int id, string name, string race, int maxHP, int ac, Speed speed, Stats stats,
            SortedDictionary<string, int> classes, int passiveInsight, int passivePerception, int passiveInvestigation) : base(id, name, race, maxHP, ac, speed, stats)
        {
            XP = 0;
            totalLevel = 1;
            levelByClass = classes;

            HitDice = 1;

            PassiveInsight = passiveInsight;
            PassivePerception = passivePerception;
            PassiveInvestigation = passiveInvestigation;
        }

        public void addXP(int XP)
        {
            if (XP > 0)
            {
                this.XP += XP;

                while (totalLevel < 20 && this.XP > XPbyLevel[this.totalLevel + 1])
                {
                    levelUp();
                }
            }
        }

        public void levelUp()
        {
            totalLevel++;
            HitDice++;

            if (levelByClass.Count == 1)
            {
                levelByClass[levelByClass.First().Key]++;
            }

            //if(nr of classes > 1) choose class (retun message?), separate method for classLevelUp

            PassiveInsight = getPassiveStat(StatsMod.WIS, proficiencyInsight);
            PassiveInvestigation = getPassiveStat(StatsMod.INT, proficiencyInvestigation);
            PassivePerception = getPassiveStat(StatsMod.WIS, proficiencyPerception);
        }

        public int getPassiveStat(int statMod, bool isProficient)
        {
            return 10 + statMod + (isProficient ? proficiencyByLevel[totalLevel] : 0);
        }
    }
}
