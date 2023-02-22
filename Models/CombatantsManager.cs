using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class CombatantsManager
    {
        private List<Creature> Combatants { get; set; }

        private readonly PlayersManager _playersManager;

        public CombatantsManager(PlayersManager playersManager)
        {
            _playersManager = playersManager;

            Combatants = new List<Creature>();
        }

        public void Reset()
        {
            Combatants.Clear();
        }

        public List<Creature> GetCombatants()
        {
            return Combatants;
        }

        public Creature GetCombatantById(int id)
        {
            return Combatants.Where(c => c.ID == id).First();
        }

        public void AddCombatant(Creature creature)
        {
            try
            {
                Combatants.Add(creature);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void HealCombatantWithId(int id, int hp)
        {
            if (hp > 0)
            {
                //if is player
                if (id < _playersManager.GetPlayers().Count)
                {
                    _playersManager.HealPlayerWithId(id, hp);
                }
                else //if is monster
                {
                    Creature combatant = GetCombatantById(id);

                    combatant.HP += hp;

                    if (combatant.HP > combatant.MaxHP)
                    {
                        combatant.HP = combatant.MaxHP;
                    }
                }
            }
        }

        ///<summary>
        ///Descreases the hp of combatant with id "id" by the value of "dmg". 
        ///Returns 2 if combatant has died, 1 if combatant is unconscious, 0 otherwise.
        ///</summary>
        public int DamageCombatantWithId(int id, int dmg)
        {
            if (dmg > 0)
            {
                //if is player
                if (id < _playersManager.GetPlayers().Count)
                {
                    return _playersManager.DamagePlayerWithId(id, dmg);
                }
                else //if is monster
                {
                    Creature combatant = GetCombatantById(id);

                    combatant.HP -= dmg;

                    if (combatant.HP <= 0)
                    {
                        combatant.HP = 0;

                        return 2;
                    }
                }
            }

            return 0;
        }

        public void SortByInitiative()
        {
            Combatants = Combatants.OrderByDescending(c => c.Initiative).ToList();
        }
    }
}
