using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.JsonManagers;
using Deez_Notes_Dm.Models;

namespace Deez_Notes_Dm.Services
{
    public class PlayerCreatorService
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerCreatorService()
        {
            _playersJsonManager = PlayersJsonManager.Instance;
        }

        public void CreatePlayer(Player player)
        {
            PlayerDTO playerDTO = ToPlayerDTO(player);

            _playersJsonManager.Players.Add(playerDTO);

            _playersJsonManager.SavePlayers();
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
                totalLevel = player.totalLevel,
                levelByClass = player.levelByClass,
                HitDice = player.HitDice,
                PassiveInsight = player.PassiveInsight,
                PassivePerception = player.PassivePerception,
                PassiveInvestigation = player.PassiveInvestigation
            };
        }
    }
}
