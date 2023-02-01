using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.JsonManagers;
using Deez_Notes_Dm.Models;
using System.Linq;

namespace Deez_Notes_Dm.Services
{
    public class PlayerUpdateService
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerUpdateService()
        {
            _playersJsonManager = PlayersJsonManager.Instance;
        }
        private static Player ToPlayer(PlayerDTO p)
        {
            return new Player(p.ID, p.Name, p.Race, p.HP, p.MaxHP, p.AC, p.Speeds, p.BaseStats, p.XP, p.levelByClass, p.HitDice, p.PassiveInsight, p.PassivePerception, p.PassiveInvestigation);
        }

        private PlayerDTO ToPlayerDTO(Player player)
        {
            return new PlayerDTO()
            {
                ID = player.ID,
                Name = player.Name,
                Race = player.Race,
                MaxHP = player.MaxHP,
                HP = player.HP,
                AC = player.AC,
                Speeds = player.Speeds,
                BaseStats = player.BaseStats,
                XP = player.XP,
                levelByClass = player.levelByClass,
                HitDice = player.HitDice,
                PassiveInsight = player.PassiveInsight,
                PassivePerception = player.PassivePerception,
                PassiveInvestigation = player.PassiveInvestigation
            };
        }

        public void AddXpToPlayer(int id, int xp)
        {
            if (xp > 0)
            {
                Player player = ToPlayer(_playersJsonManager.Players[id]);

                player.XP += xp;

                while (player.totalLevel < 20 && player.XP > Player.XPbyLevel[player.totalLevel + 1])
                {
                    LevelUpPlayer(player);
                }

                _playersJsonManager.Players[id] = ToPlayerDTO(player);

                _playersJsonManager.SavePlayers();
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


            _playersJsonManager.Players[player.ID] = ToPlayerDTO(player);

            _playersJsonManager.SavePlayers();
        }

        public void HealPlayer(int id, int hp)
        {
            Player player = ToPlayer(_playersJsonManager.Players.Where((p) => p.ID == id).First());// ToPlayer(_playersJsonManager.Players[id]);

            if (hp > 0 && player.HP + hp <= player.MaxHP)
            {
                player.HP += hp;

                _playersJsonManager.Players[id] = ToPlayerDTO(player);

                _playersJsonManager.SavePlayers();
            }
        }

        public void DamagePlayer(int id, int dmg)
        {
            if (dmg > 0)
            {
                Player player = ToPlayer(_playersJsonManager.Players.Where((p) => p.ID == id).First());// ToPlayer(_playersJsonManager.Players[id]);

                player.HP -= dmg;

                _playersJsonManager.Players[id] = ToPlayerDTO(player);

                _playersJsonManager.SavePlayers();

                if (player.HP < 0)
                {
                    player.HP = 0;
                }
            }

            
        }
    }
}
