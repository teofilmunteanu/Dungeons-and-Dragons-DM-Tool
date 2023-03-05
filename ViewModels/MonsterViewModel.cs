using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using static Deez_Notes_Dm.Models.Creature;
using static Deez_Notes_Dm.Models.Monster;

namespace Deez_Notes_Dm.ViewModels
{
    public class MonsterViewModel : ViewModelBase
    {
        public int ID { get; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }

        public List<string> SpeedsList { get; set; }

        public Stats BaseStats { get; set; }

        public Stats StatsMod { get; set; }

        public double Initiative { get; set; }

        private string notes;
        public string Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
                if (UpdateNotesCommand != null)
                {
                    UpdateNotesCommand.Execute(null);
                }
            }
        }



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


        public ICommand UpdateNotesCommand { get; }


        public MonsterViewModel(Monster monster, MonstersManager monstersManager)
        {
            ID = monster.ID;
            Name = monster.Name;
            Race = monster.Race;
            HP = monster.HP;
            MaxHP = monster.MaxHP;
            AC = monster.AC;
            SpeedsList = new List<string>();
            if (monster.Speeds is not null)
            {
                SpeedsList = ToSpeedList(monster.Speeds);
            }
            BaseStats = monster.BaseStats;
            StatsMod = monster.StatsMod;
            Initiative = monster.Initiative;
            Notes = monster.Notes;

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

            UpdateNotesCommand = new UpdateMonsterNotesCommand(this, monstersManager);
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

        public List<string> ToSpeedList(Speed speeds)
        {
            List<string> SpeedsList = new List<string>();
            foreach (PropertyInfo prop in speeds.GetType().GetProperties())
            {
                if (prop.Name != "hover")
                {
                    int? speedVal = (int?)prop.GetValue(speeds);

                    if (speedVal != 0 && speedVal != null)
                    {
                        SpeedsList.Add($"{prop.Name} {speedVal} ft");
                    }
                }
                else if (speeds.hover != null && speeds.hover == true)
                {
                    SpeedsList.Add("hovers");
                }
            }

            return SpeedsList;
        }
    }
}
