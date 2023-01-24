namespace Deez_Notes_Dm.Models
{
    public class Monster : Creature
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public double ChallengeRating { get; set; }
        public int XP_Drop { get; set; }


        public string HP_Roll { get; set; }


        public string[] Languages { get; set; }

        //dmg immunities, condition immunities
        public string Senses { get; set; }
        public string Skills { get; set; }
        public Stats SavingThrows { get; set; }
        public string[] Abilities { get; set; }
        public string[] Actions { get; set; }
        public string[] LegendaryActions { get; set; }

        public Monster()
        {

        }

        public Monster(int id, string name, string race, int hp, int maxHP, int ac, Speed speed, Stats stats,
            string size, string alignment, string hp_roll, Stats savingThrows, string skills, string senses, string[] languages,
            double challengeRating, int xp_Drop, string[] traits, string[] actions, string[] legendaryActions) : base(id, name, race, hp, maxHP, ac, speed, stats)
        {
            Size = size;
            Alignment = alignment;
            HP_Roll = hp_roll;
            SavingThrows = savingThrows;
            Skills = skills;
            Senses = senses;
            Languages = languages;
            ChallengeRating = challengeRating;
            XP_Drop = xp_Drop;
            Abilities = traits;
            Actions = actions;
            LegendaryActions = legendaryActions;
        }
    }
}
