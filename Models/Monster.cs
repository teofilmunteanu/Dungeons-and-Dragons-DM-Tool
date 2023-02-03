namespace Deez_Notes_Dm.Models
{
    public class Monster : Creature
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public Stats SavingThrows { get; set; }
        //if null, take deafult(calculate)
        public string Skills { get; set; }
        public string Senses { get; set; }

        public string Languages { get; set; }


        public double ChallengeRating { get; set; }
        public int XP_Drop { get; set; } // generate using challangeRating


        public string[] Actions { get; set; } //make class?
        public string[] Reactions { get; set; }


        public string LegendaryActionDescription { get; set; }
        public string[] LegendaryActions { get; set; }

        public string[] SpecialAbilities { get; set; }

        public Monster()
        {

        }

        //public Monster(int id, string name, string race, int hp, int maxHP, int ac, Speed speed, Stats stats,
        //    string size, string alignment, string hit_dice, Stats savingThrows, string skills, string senses, string languages,
        //    double challengeRating, int xp_Drop, string[] traits, string[] actions, string[] legendaryActions) : base(id, name, race, hp, maxHP, ac, speed, stats)
        //{
        //    Size = size;
        //    Alignment = alignment;
        //    Hit_Dice = hit_dice;
        //    SavingThrows = savingThrows;
        //    Skills = skills;
        //    Senses = senses;
        //    Languages = languages;
        //    ChallengeRating = challengeRating;
        //    XP_Drop = xp_Drop;
        //    Abilities = traits;
        //    Actions = actions;
        //    LegendaryActions = legendaryActions;
        //}
    }
}
