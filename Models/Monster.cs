using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    public class Monster : Creature
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public SavingStats SavingThrows { get; set; }

        public string Skills { get; set; }

        public string? DamageVulnerabilities { get; set; }
        public string? DamageResistances { get; set; }
        public string? DamageImmunities { get; set; }
        public string? ConditionImmunities { get; set; }

        public string? Senses { get; set; }

        public string Languages { get; set; }


        public string ChallengeRating { get; set; }

        // TO COMPLETE
        public static readonly Dictionary<string, int> XPbyCR = new Dictionary<string, int>
        {
            {"0",0},
            {"1/8", 25},
            {"1/4", 50},
            {"1/2", 100},
            {"1", 200},
            {"2", 450}
        };
        public int XP_Drop { get; set; }


        public Action[]? Actions { get; set; }
        public Action[]? Reactions { get; set; }


        public string? LegendaryActionDescription { get; set; }
        public Action[]? LegendaryActions { get; set; }

        public Action[]? SpecialAbilities { get; set; }

        public Monster()
        {

        }

        //At the mosnter creator service: if id> players.count, then it's a mosnter
        //Show on right stats of monster with id same as current creature(cuz the monster attributes can't be accessed from the creature class)
        public Monster(int id, string name, string race, int maxHP, int ac, Speed speeds, Stats stats,
            string size, string alignment, string hit_Dice, SavingStats savingThrows, string skills,
            string? damageVulnerabilities, string? damageResistances, string? damageImmunities, string? conditionImmunities,
            string? senses, string languages, string challengeRating, int xp_Drop, Action[]? actions, Action[]? reactions,
            string? legendaryActionDescription, Action[]? legendaryActions, Action[]? specialAbilities) : base(id, name, race, maxHP, maxHP, ac, speeds, stats)
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
        }

        public class Action
        {
            public string name;
            public string description;
            public int? attackBonus;
            public string? damageDice;
            public int? damageBonus;
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
    }
}
