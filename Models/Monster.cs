using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    public class Monster : Creature
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public SavingStats SavingThrows { get; set; }

        public SkillsStats Skills { get; set; }

        public string? DamageVulnerabilities { get; set; }
        public string? DamageResistances { get; set; }
        public string? DamageImmunities { get; set; }
        public string? ConditionImmunities { get; set; }

        public string? Senses { get; set; }

        public string Languages { get; set; }


        public string ChallengeRating { get; set; }

        public static readonly Dictionary<string, int> XPbyCR = new Dictionary<string, int>
        {
            {"0",0},
            {"1/8", 25},
            {"1/4", 50},
            {"1/2", 100},
            {"1", 200},
            {"2", 450},
            {"3", 700 },
            {"4", 1100 },
            {"5", 1800 },
            {"6", 2300 },
            {"7", 2900 },
            {"8", 3900 },
            {"9", 5000 },
            {"10", 5900 },
            {"11", 7200 },
            {"12", 8400 },
            {"13", 10000 },
            {"14", 11500 },
            {"15", 13000 },
            {"16", 15000 },
            {"17", 18000 },
            {"18", 20000 },
            {"19", 22000 },
            {"20", 25000 },
            {"21", 33000 },
            {"22", 41000 },
            {"23", 50000 },
            {"24", 62000 },
            {"25", 75000 },
            {"26", 90000 },
            {"27", 105000 },
            {"28", 120000 },
            {"29", 142000 },
            {"30", 155000 }
        };
        public int XP_Drop { get; set; }

        public List<Action>? Actions { get; set; }
        public List<Action>? Reactions { get; set; }


        public string? LegendaryActionDescription { get; set; }
        public List<Action>? LegendaryActions { get; set; }

        public List<Action>? SpecialAbilities { get; set; }
        public List<Spell>? Spells { get; set; }

        public Monster()
        {

        }

        //At the mosnter creator service: if id> players.count, then it's a mosnter
        //Show on right stats of monster with id same as current creature(cuz the monster attributes can't be accessed from the creature class)
        public Monster(int id, string name, string race, int maxHP, int ac, Speed speeds, Stats stats,
            string size, string alignment, string hit_Dice, SavingStats savingThrows, SkillsStats skills,
            string? damageVulnerabilities, string? damageResistances, string? damageImmunities, string? conditionImmunities,
            string? senses, string languages, string challengeRating, int xp_Drop, List<Action>? actions, List<Action>? reactions,
            string? legendaryActionDescription, List<Action>? legendaryActions, List<Action>? specialAbilities, List<Spell>? spells) : base(id, name, race, maxHP, maxHP, ac, speeds, stats)
        {
            Size = size;
            Alignment = alignment;
            Hit_Dice = hit_Dice;
            SavingThrows = savingThrows;
            Skills = skills;
            DamageVulnerabilities = damageVulnerabilities;
            DamageResistances = damageResistances;
            DamageImmunities = damageImmunities;
            ConditionImmunities = conditionImmunities;
            Senses = senses;
            Languages = languages;
            ChallengeRating = challengeRating;
            XP_Drop = xp_Drop;
            Actions = actions;
            Reactions = reactions;
            LegendaryActionDescription = legendaryActionDescription;
            LegendaryActions = legendaryActions;
            SpecialAbilities = specialAbilities;
            Spells = spells;
        }

        public class Action
        {
            public string name { get; set; }
            public string description { get; set; }
            public int? attackBonus { get; set; }
            public string? damageDice { get; set; }
            public int? damageBonus { get; set; }
        }

        public class SavingStats
        {
            public int? STR { get; set; }
            public int? DEX { get; set; }
            public int? CON { get; set; }
            public int? INT { get; set; }
            public int? WIS { get; set; }
            public int? CHA { get; set; }
        }

        public class SkillsStats
        {
            public int? acrobatics { get; set; }
            public int? animalHandling { get; set; }
            public int? arcana { get; set; }
            public int? athletics { get; set; }
            public int? deception { get; set; }
            public int? history { get; set; }
            public int? insight { get; set; }
            public int? intimidation { get; set; }
            public int? investigation { get; set; }
            public int? medicine { get; set; }
            public int? nature { get; set; }
            public int? perception { get; set; }
            public int? performance { get; set; }
            public int? persuasion { get; set; }
            public int? religion { get; set; }
            public int? sleightOfHand { get; set; }
            public int? stealth { get; set; }
            public int? survival { get; set; }
        }

        public class Spell
        {
            public string name { get; set; }
            public string desc { get; set; }
            public string higherLevel { get; set; }
            public string range { get; set; }
            public string components { get; set; }
            public string material { get; set; }
            public string ritual { get; set; }
            public string duration { get; set; }
            public string concentration { get; set; }
            public string castingTime { get; set; }
            public string level { get; set; }
            public string school { get; set; }
            public string dndClass { get; set; }
            public string archetype { get; set; }
            public string circles { get; set; }
        }
    }
}
