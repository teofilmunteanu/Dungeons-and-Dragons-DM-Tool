using Deez_Notes_Dm.Models;
using System.Windows.Input;
using static Deez_Notes_Dm.Models.Creature;
using static Deez_Notes_Dm.Models.Monster;

namespace Deez_Notes_Dm.ViewModels
{
    public class MonsterViewModel : CreatureViewModel
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public Stats SavingThrows { get; set; }
        //if null, take deafult(calculate)
        public string Skills { get; set; }


        public string DamageVulnerabilities { get; set; }

        public string DamageResistances { get; set; }

        public string DamageImmunities { get; set; }

        public string ConditionImmuniuties { get; set; }

        public string Senses { get; set; }

        public string Languages { get; set; }


        public double ChallengeRating { get; set; }
        public int XP_Drop { get; set; } // generate using challangeRating


        public Action[] Actions { get; set; } //make class?
        public Action[] Reactions { get; set; }


        public string LegendaryActionDescription { get; set; }
        public Action[] LegendaryActions { get; set; }

        public Action[] SpecialAbilities { get; set; }


        public ICommand AddHPCommand { get; }
        public ICommand SubtractHPCommand { get; }

        public MonsterViewModel(Monster monster) : base(monster.ID, monster.Name, monster.Race, monster.HP, monster.MaxHP, monster.AC,
            monster.Speeds, monster.BaseStats, monster.StatsMod)
        {
            Size = monster.Size;
            Alignment = monster.Alignment;
            Hit_Dice = monster.Hit_Dice;
            SavingThrows = monster.SavingThrows;
            Skills = monster.Skills;
            DamageVulnerabilities = monster.DamageVulnerabilities;
            DamageResistances = monster.DamageResistances;
            DamageImmunities = monster.DamageImmunities;
            ConditionImmuniuties = ConditionImmuniuties;
            Senses = monster.Senses;
            Languages = monster.Languages;
            ChallengeRating = monster.ChallengeRating;
            XP_Drop = monster.XP_Drop;
            Actions = monster.Actions;
            Reactions = monster.Reactions;
            LegendaryActionDescription = monster.LegendaryActionDescription;
            LegendaryActions = monster.LegendaryActions;
            SpecialAbilities = monster.SpecialAbilities;

            //creatureManager????
            //AddHPCommand = new AddHPCommand(this, playerListViewModel, playersManager); 
            //SubtractHPCommand = new SubtractHPCommand(this, playerListViewModel, playersManager); 
        }
    }
}
