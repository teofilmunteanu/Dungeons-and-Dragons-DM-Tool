﻿using Deez_Notes_Dm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class PlayersManager
    {
        private List<Player> Players;

        public PlayersManager()
        {
            Players = PlayerServices.GetPlayersData();
        }

        public List<Player> GetPlayers()
        {
            return Players;
        }

        public Player GetPlayerById(int id)
        {
            return Players.Where(p => p.ID == id).First();
        }

        public void AddPlayer(Player player)
        {
            try
            {
                Players.Add(player);
                PlayerServices.UpdatePlayerDataWith(Players);
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

                PlayerServices.UpdatePlayerDataWith(Players);
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

            PlayerServices.UpdatePlayerDataWith(Players);
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

                PlayerServices.UpdatePlayerDataWith(Players);
            }
        }

        ///<summary>
        ///Descreases the hp of player with id "id" by the value of "dmg". 
        ///Returns 2 if player has died, 1 if player is unconscious, 0 otherwise.
        ///</summary>
        public int DamagePlayerWithId(int id, int dmg)
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
                        PlayerServices.UpdatePlayerDataWith(Players);

                        return 2;
                    }

                    player.HP = 0;
                }

                PlayerServices.UpdatePlayerDataWith(Players);

                if (player.HP == 0)
                {
                    return 1;
                }
            }

            return 0;
        }

        public void SetNotesToPlayerWithId(int id, string notes)
        {
            Player player = GetPlayerById(id);
            player.Notes = notes;

            PlayerServices.UpdatePlayerDataWith(Players);
        }
    }
}
