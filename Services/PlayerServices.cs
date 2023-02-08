using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.JsonManagers;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Services
{
    public class PlayerServices
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerServices()
        {
            _playersJsonManager = PlayersJsonManager.Instance;
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

        private Player ToPlayer(PlayerDTO p)
        {
            return new Player(p.ID, p.Name, p.Race, p.HP, p.MaxHP, p.AC, p.Speeds, p.BaseStats, p.XP, p.levelByClass, p.HitDice, p.PassiveInsight, p.PassivePerception, p.PassiveInvestigation);
        }

        public List<Player> GetPlayersData()
        {
            List<PlayerDTO> playerDTOs = _playersJsonManager.GetPlayersFromJson();

            return playerDTOs.Select(p => ToPlayer(p)).ToList();
        }

        public void UpdatePlayerData(List<Player> players)
        {
            List<PlayerDTO> playerDTOs = players.Select(p => ToPlayerDTO(p)).ToList();
            _playersJsonManager.SavePlayers(playerDTOs);
        }
    }
}
