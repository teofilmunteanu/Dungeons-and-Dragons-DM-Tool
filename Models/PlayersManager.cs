using Deez_Notes_Dm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class PlayersManager
    {
        private readonly PlayerProviderService _playerProviderService;
        private readonly PlayerCreatorService _playerCreatorService;
        private readonly PlayerUpdateService _playerUpdateService;

        public PlayersManager(PlayerProviderService playerProviderService, PlayerCreatorService playerCreatorService, PlayerUpdateService playerUpdateService)
        {
            _playerProviderService = playerProviderService;
            _playerCreatorService = playerCreatorService;
            _playerUpdateService = playerUpdateService;
        }

        public List<Player> GetPlayers()
        {
            return _playerProviderService.GetPlayers();
        }

        public Player GetPlayerById(int id)
        {
            return _playerProviderService.GetPlayerById(id);
        }

        public void AddPlayer(Player player)
        {
            try
            {
                _playerCreatorService.CreatePlayer(player);
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

                _playerUpdateService.UpdatePlayer(player);
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

            _playerUpdateService.UpdatePlayer(player);
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

                _playerUpdateService.UpdatePlayer(player);
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
                        _playerUpdateService.UpdatePlayer(player);

                        return true;
                    }

                    player.HP = 0;
                }

                _playerUpdateService.UpdatePlayer(player);
            }

            return false;
        }
    }
}
