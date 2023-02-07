using Deez_Notes_Dm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class PlayersManager
    {
        private readonly PlayerServices _playerServices;

        public PlayersManager(PlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        public List<Player> GetPlayers()
        {
            return _playerServices.GetPlayers();
        }

        public Player GetPlayerById(int id)
        {
            return _playerServices.GetPlayerById(id);
        }

        public void AddPlayer(Player player)
        {
            try
            {
                _playerServices.CreatePlayer(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddXpToPlayerWithId(int id, int xp)
        {
            if (xp > 0)
            {
                Player player = GetPlayerById(id);

                player.XP += xp;

                while (player.totalLevel < 20 && player.XP > Player.XPbyLevel[player.totalLevel + 1])
                {
                    LevelUpPlayer(player);
                }

                _playerServices.UpdatePlayer(player);
            }
        }

        public void LevelUpPlayer(Player player)
        {
            if (player.levelByClass.Count == 1)
            {
                player.levelByClass[player.levelByClass.First().Key]++;
            }
            //else choose class to level

            player.totalLevel++;
            player.HitDice++;

            player.PassiveInsight = player.getPassiveStat(player.StatsMod.WIS, player.ProficiencyInsight);
            player.PassivePerception = player.getPassiveStat(player.StatsMod.WIS, player.ProficiencyPerception);
            player.PassiveInvestigation = player.getPassiveStat(player.StatsMod.INT, player.ProficiencyInvestigation);

            _playerServices.UpdatePlayer(player);
        }

        public void HealPlayerWithId(int id, int hp)
        {
            if (hp > 0)
            {
                Player player = GetPlayerById(id);

                player.HP += hp;

                if (player.HP > player.MaxHP)
                {
                    player.HP = player.MaxHP;
                }

                _playerServices.UpdatePlayer(player);
            }
        }

        ///<summary>
        ///Descreases the hp of player with id "id" by the value of "dmg". 
        ///Returns true if player has died, false otherwise.
        ///</summary>
        public bool DamagePlayerWithId(int id, int dmg)
        {
            if (dmg > 0)
            {
                Player player = GetPlayerById(id);

                player.HP -= dmg;

                if (player.HP < 0)
                {
                    if (-player.HP >= player.MaxHP)
                    {
                        player.HP = 0;
                        _playerServices.UpdatePlayer(player);

                        return true;
                    }

                    player.HP = 0;
                }

                _playerServices.UpdatePlayer(player);
            }

            return false;
        }
    }
}
