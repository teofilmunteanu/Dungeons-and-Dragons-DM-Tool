using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.JsonManagers;
using Deez_Notes_Dm.Models;

namespace Deez_Notes_Dm.Services
{
    public class PlayerUpdateService
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerUpdateService()
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

        public void UpdatePlayer(Player player)
        {
            int index = _playersJsonManager.Players.FindIndex(p => p.ID == player.ID);
            _playersJsonManager.Players[index] = ToPlayerDTO(player);

            _playersJsonManager.SavePlayers();
        }
    }
}
