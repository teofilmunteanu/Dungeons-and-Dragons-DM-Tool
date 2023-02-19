using Deez_Notes_Dm.DataManagers;
using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Services
{
    public static class PlayerServices
    {
        private static PlayerDTO ToPlayerDTO(Player player)
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

        private static Player ToPlayer(PlayerDTO p)
        {
            return new Player(p.ID, p.Name, p.Race, p.HP, p.MaxHP, p.AC, p.Speeds, p.BaseStats, p.XP, p.levelByClass, p.HitDice, p.PassiveInsight, p.PassivePerception, p.PassiveInvestigation);
        }

        public static List<Player> GetPlayersData()
        {
            List<PlayerDTO>? playerDTOs = PlayersJsonManager.GetPlayersFromJson();

            if (playerDTOs != null)
            {
                return playerDTOs.Select(p => ToPlayer(p)).ToList();
            }
            else
            {
                return new List<Player>();
            }
        }

        public static void UpdatePlayerDataWith(List<Player> players)
        {
            List<PlayerDTO> playerDTOs = players.Select(p => ToPlayerDTO(p)).ToList();
            PlayersJsonManager.SavePlayers(playerDTOs);
        }
    }
}
