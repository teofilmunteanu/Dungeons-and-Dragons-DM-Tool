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
            return new Player(p.ID, p.Name, p.Race, p.MaxHP, p.AC, p.Speeds, p.BaseStats, p.XP, p.levelByClass, p.HitDice, p.PassiveInsight, p.PassivePerception, p.PassiveInvestigation);
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

        //sometimes doesnt work
        public void AddXpToPlayer(int id, int xp)
        {
            if (xp > 0)
            {
                Player player = ToPlayer(_playersJsonManager.Players[id]);

                player.XP += xp;

                while (player.totalLevel < 20 && player.XP > Player.XPbyLevel[player.totalLevel + 1])
                {
                    LevelUpPlayer(id);
                    player = ToPlayer(_playersJsonManager.Players[id]);
                }

                _playersJsonManager.Players[id] = ToPlayerDTO(player);

                _playersJsonManager.SavePlayers();
            }
        }

        public void LevelUpPlayer(int id)
        {
            Player player = ToPlayer(_playersJsonManager.Players[id]);

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


            _playersJsonManager.Players[id] = ToPlayerDTO(player);

            _playersJsonManager.SavePlayers();
        }
    }
}
