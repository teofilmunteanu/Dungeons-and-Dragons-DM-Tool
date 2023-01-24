using Deez_Notes_Dm.Services;
using System;
using System.Collections.Generic;
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
            _playerUpdateService.AddXpToPlayer(id, xp);
        }

        public void HealPlayerWithId(int id, int hp)
        {
            _playerUpdateService.HealPlayer(id, hp);
        }

        public void DamagePlayerWithId(int id, int dmg)
        {
            _playerUpdateService.DamagePlayer(id, dmg);
        }
    }
}
