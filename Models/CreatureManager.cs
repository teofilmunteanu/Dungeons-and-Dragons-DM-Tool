using Deez_Notes_Dm.Services;
using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Models
{
    public class CreatureManager
    {
        public List<Creature> Creatures { get; set; }

        public CreatureManager(PlayerServices playerServices)
        {
            Creatures = GetCreatures();
        }

        public List<Creature> GetCreatures()
        {
            Creatures.Clear();
            //Creatures.AddRange(playersmanager.GetPlayers());
            //Creatures.AddRange(Monsters);

            return Creatures;
        }

        public Creature GetCreatureById(int id)
        {
            return Creatures.Where(c => c.ID == id).First();
        }

        //public void HealPlayerWithId(int id, int hp)
        //{
        //    if (hp > 0)
        //    {
        //        Player player = GetPlayerById(id);

        //        player.HP += hp;

        //        if (player.HP > player.MaxHP)
        //        {
        //            player.HP = player.MaxHP;
        //        }

        //        _playerUpdateService.UpdatePlayer(player);
        //    }
        //}

        /////<summary>
        /////Descreases the hp of player with id "id" by the value of "dmg". 
        /////Returns true if player has died, false otherwise.
        /////</summary>
        //public bool DamagePlayerWithId(int id, int dmg)
        //{
        //    if (dmg > 0)
        //    {
        //        Player player = GetPlayerById(id);

        //        player.HP -= dmg;

        //        if (player.HP < 0)
        //        {
        //            if (-player.HP >= player.MaxHP)
        //            {
        //                player.HP = 0;
        //                _playerUpdateService.UpdatePlayer(player);

        //                return true;
        //            }

        //            player.HP = 0;
        //        }

        //        _playerUpdateService.UpdatePlayer(player);
        //    }

        //    return false;
        //}
    }
}
