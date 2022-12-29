using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.JsonManagers;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Services
{
    public class PlayerProviderService
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerProviderService()
        {
            _playersJsonManager = PlayersJsonManager.Instance;
        }

        public List<Player> GetPlayers()
        {
            List<PlayerDTO> playerDTOs = _playersJsonManager.GetPlayers();
            List<Player> players = new List<Player>();

            return playerDTOs.Select(p => ToPlayer(p)).ToList<Player>();
        }

        private static Player ToPlayer(PlayerDTO p)
        {
            return new Player(p.ID, p.Name, p.Race, p.MaxHP, p.AC, p.Speeds, p.BaseStats, p.levelByClass, p.PassiveInsight, p.PassivePerception, p.PassiveInvestigation);
        }
    }
}
