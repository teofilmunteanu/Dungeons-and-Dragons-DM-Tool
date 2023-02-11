using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.ViewModels
{
    public class CreatureViewModel : ViewModelBase
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

        private string hpInput;
        public string HP_Input
        {
            get => hpInput;
            set
            {
                hpInput = value;
                OnPropertyChanged(nameof(HP_Input));
            }
        }


        public ICommand AddHPCommand { get; }
        public ICommand SubtractHPCommand { get; }

        //for inheritance
        public CreatureViewModel(int id, string name, string race, int hp, int maxHP, int ac,
            Speed speeds, Stats baseStats, Stats statsMod)
        {
            ID = id;
            Name = name;
            Race = race;
            HP = hp;
            MaxHP = maxHP;
            AC = ac;
            BaseStats = baseStats;
            StatsMod = statsMod;

            SpeedsList = new List<string>();
            if (speeds is not null)
            {
                SpeedsList = ToSpeedList(speeds);
            }
        }

        //for combat list
        public CreatureViewModel(Creature creature, CombatListViewModel combatListViewModel, CombatantsManager combatantsManager)
        {
            ID = creature.ID;
            Name = creature.Name;
            Race = creature.Race;
            HP = creature.HP;
            MaxHP = creature.MaxHP;
            AC = creature.AC;
            BaseStats = creature.BaseStats;
            StatsMod = creature.StatsMod;

            SpeedsList = new List<string>();
            if (creature.Speeds is not null)
            {
                SpeedsList = ToSpeedList(creature.Speeds);
            }

            AddHPCommand = new AddHPCombatCommand(this, combatListViewModel, combatantsManager);
            SubtractHPCommand = new SubtractHPCombatCommand(this, combatListViewModel, combatantsManager);
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
