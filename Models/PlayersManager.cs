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

        public PlayersManager(PlayerProviderService playerProviderService, PlayerCreatorService playerCreatorService)
        {
            _playerProviderService = playerProviderService;
            _playerCreatorService = playerCreatorService;
        }

        public List<Player> GetPlayers()
        {
            return _playerProviderService.GetPlayers();
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
    }
}
