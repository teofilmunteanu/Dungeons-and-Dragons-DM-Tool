namespace Deez_Notes_Dm.Models
{
    public class Monster : Creature
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public Stats SavingThrows { get; set; }

        public string Skills { get; set; }

        public string DamageVulnerabilities { get; set; }
        public string DamageResistances { get; set; }
        public string DamageImmunities { get; set; }
        public string ConditionImmunities { get; set; }

        public string Senses { get; set; }

        public string Languages { get; set; }


        public double ChallengeRating { get; set; }
        public int XP_Drop { get; set; }


        public Action[] Actions { get; set; }
        public Action[] Reactions { get; set; }


        public string LegendaryActionDescription { get; set; }
        public Action[] LegendaryActions { get; set; }

        public Action[] SpecialAbilities { get; set; }

        public Monster()
        {

        }

        public Monster(int id, string name, string race, int maxHP, int ac, Speed speeds, Stats stats,
            string size, string alignment, string hit_Dice, Stats savingThrows, string skills,
            string damageVulnerabilities, string damageResistances, string damageImmunities, string conditionImmunities,
            string senses, string languages, double challengeRating, int xP_Drop, Action[] actions, Action[] reactions,
            string legendaryActionDescription, Action[] legendaryActions, Action[] specialAbilities) : base(id, name, race, maxHP, maxHP, ac, speeds, stats)
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
            XP_Drop = xP_Drop;
            Actions = actions;
            Reactions = reactions;
            LegendaryActionDescription = legendaryActionDescription;
            LegendaryActions = legendaryActions;
            SpecialAbilities = specialAbilities;
        }

        public class Action
        {
            string name;
            string description;
            int? attackBonus;
            string? damageDice;
            int? damageBonus;
        }
    }
}
