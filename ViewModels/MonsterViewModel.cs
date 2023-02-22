using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using static Deez_Notes_Dm.Models.Monster;

namespace Deez_Notes_Dm.ViewModels
{
    public class MonsterViewModel : CreatureViewModel
    {
        public string Size { get; set; }
        public string Alignment { get; set; }


        public string Hit_Dice { get; set; }

        public string SavingThrowsString { get; set; }

        public string SkillsString { get; set; }


        public string DamageVulnerabilities { get; set; }

        public string DamageResistances { get; set; }

        public string DamageImmunities { get; set; }

        public string ConditionImmunities { get; set; }

        public string Senses { get; set; }

        public string Languages { get; set; }


        public string ChallengeRating { get; set; }
        public int XP_Drop { get; set; }


        public List<ActionStats> Actions { get; set; }
        public List<ActionStats> Reactions { get; set; }


        public string LegendaryActionDescription { get; set; }
        public List<ActionStats> LegendaryActions { get; set; }

        public List<ActionStats> SpecialAbilities { get; set; }
        public List<Spell> Spells { get; set; }


        public ICommand AddHPCommand { get; }
        public ICommand SubtractHPCommand { get; }

        public MonsterViewModel(Monster monster) : base(monster.ID, monster.Name, monster.Race, monster.HP, monster.MaxHP, monster.AC,
            monster.Speeds, monster.BaseStats, monster.StatsMod, monster.Initiative)
        {
            Size = monster.Size;
            Alignment = monster.Alignment;
            Hit_Dice = monster.Hit_Dice;
            SavingThrowsString = SavingThrowsToString(monster.SavingThrows);
            SkillsString = SkillsToString(monster.Skills);
            DamageVulnerabilities = monster.DamageVulnerabilities;
            DamageResistances = monster.DamageResistances;
            DamageImmunities = monster.DamageImmunities;
            ConditionImmunities = monster.ConditionImmunities;
            Senses = monster.Senses;
            Languages = monster.Languages;
            ChallengeRating = monster.ChallengeRating;
            XP_Drop = monster.XP_Drop;
            Actions = monster.Actions;
            Reactions = monster.Reactions;
            LegendaryActionDescription = monster.LegendaryActionDescription;
            LegendaryActions = monster.LegendaryActions;
            SpecialAbilities = monster.SpecialAbilities;
            Spells = monster.Spells;
        }

        private string SavingThrowsToString(SavingStats savingThrows)
        {
            string savingThrowsString = "";
            foreach (PropertyInfo prop in savingThrows.GetType().GetProperties())
            {
                int? savingThrowVal = (int?)prop.GetValue(savingThrows);

                if (savingThrowsString != "" && savingThrowVal != null)
                {
                    savingThrowsString += ", ";
                }

                if (savingThrowVal != 0 && savingThrowVal != null)
                {
                    savingThrowsString += ($"{prop.Name}+{savingThrowVal} ");
                }
            }

            return savingThrowsString;
        }

        private string SkillsToString(SkillsStats skills)
        {
            string skillsString = "";
            PropertyInfo[] skillsProps = skills.GetType().GetProperties();
            foreach (PropertyInfo p in skillsProps)
            {
                int? skillValue = (int?)p.GetValue(skills);

                if (skillsString != "" && skillValue != null)
                {
                    skillsString += ", ";
                }

                if (p.GetValue(skills) != null)
                {
                    skillsString += p.Name + "+" + skillValue + " ";
                }
            }

            return skillsString;
        }
    }
}
