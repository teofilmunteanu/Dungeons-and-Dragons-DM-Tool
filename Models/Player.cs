using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{

    public class Player : Creature
    {
        public static readonly int[] XPbyLevel = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };

        public int xp { get; set; }
        public int XP
        {
            get => xp;
            set
            {
                xp = value;
            }
        }

        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; } = new SortedDictionary<string, int>();


        public int HitDice { get; set; }


        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }

        private static readonly int[] proficiencyByLevel = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };

        public bool ProficiencyInsight;
        public bool ProficiencyPerception;
        public bool ProficiencyInvestigation;

        public Player()
        {

        }

        //for creator
        public Player(int id, string name, string race, int maxHP, int ac, Speed speed, Stats stats,
            string _class, bool proficiency_insight, bool proficiency_perception, bool proficiency_investigation) : base(id, name, race, maxHP, maxHP, ac, speed, stats)
        {
            XP = 0;
            totalLevel = 1;
            levelByClass.Add(_class, 1);

            HitDice = 1;

            ProficiencyInsight = proficiency_insight;
            ProficiencyPerception = proficiency_perception;
            ProficiencyInvestigation = proficiency_investigation;

            PassiveInsight = getPassiveStat(StatsMod.WIS, ProficiencyInsight);
            PassivePerception = getPassiveStat(StatsMod.WIS, ProficiencyPerception);
            PassiveInvestigation = getPassiveStat(StatsMod.INT, ProficiencyInvestigation);
        }

        //for provider
        public Player(int id, string name, string race, int hp, int maxHP, int ac, Speed speed, Stats stats,
            int xp, SortedDictionary<string, int> classes, int hitDiceLeft, int passiveInsight, int passivePerception, int passiveInvestigation) : base(id, name, race, hp, maxHP, ac, speed, stats)
        {
            XP = xp;
            foreach (var item in classes)
            {
                totalLevel += item.Value;
            }

            levelByClass = classes;

            HitDice = hitDiceLeft;

            PassiveInsight = passiveInsight;
            PassivePerception = passivePerception;
            PassiveInvestigation = passiveInvestigation;
        }

        public int getPassiveStat(int statMod, bool isProficient)
        {
            return 10 + statMod + (isProficient ? proficiencyByLevel[totalLevel] : 0);
        }

        public static int getPassiveStat(int statMod, bool isProficient, int totalLevel)
        {
            return 10 + statMod + (isProficient ? proficiencyByLevel[totalLevel] : 0);
        }
    }
}
