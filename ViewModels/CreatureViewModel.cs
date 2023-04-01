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

        //to change TempHP
        private int maxHP { get; set; }
        public int MaxHP
        {
            get => maxHP;
            set
            {
                maxHP = value;
                OnPropertyChanged(nameof(MaxHP));

                TempMaxHP = value;
            }
        }

        private int hp;
        public int HP
        {
            get => hp;
            set
            {
                hp = value;
                if (hp > 0)
                {
                    Opacity = 1;
                }
                else
                {
                    Opacity = 0.5;
                }

            }
        }
        public int AC { get; set; }

        public List<string> SpeedsList { get; set; }

        public Stats BaseStats { get; set; }

        public Stats StatsMod { get; set; }

        private double initiative;
        public double Initiative
        {
            get => initiative;
            set
            {
                initiative = (int)value;
                OnPropertyChanged(nameof(Initiative));
                if (this != null && (int)value != 0 && SortCombatListCommand != null)
                {
                    SortCombatListCommand.Execute(null);
                }
            }
        }

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

        private double opacity = 1;
        public double Opacity
        {
            get => opacity;
            set
            {
                opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }

        private int tempMaxHP = 0;
        public int TempMaxHP {
            get => tempMaxHP;
            set
            {
                tempMaxHP = value;
            }
        }

        public ICommand AddHPCommand { get; }
        public ICommand SubtractHPCommand { get; }
        public ICommand SortCombatListCommand { get; }



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
            Initiative = creature.Initiative;

            SpeedsList = new List<string>();
            if (creature.Speeds is not null)
            {
                SpeedsList = ToSpeedList(creature.Speeds);
            }

            AddHPCommand = new AddHPCombatCommand(this, combatListViewModel, combatantsManager);
            SubtractHPCommand = new SubtractHPCombatCommand(this, combatListViewModel, combatantsManager);
            SortCombatListCommand = new SortCombatListCommand(this, combatListViewModel, combatantsManager);
        }

        public static List<string> ToSpeedList(Speed speeds)
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
