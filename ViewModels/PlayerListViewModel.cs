﻿using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PlayerViewModel> _players;
        private readonly PlayersManager _playersManager;

        public ObservableCollection<PlayerViewModel> Players => _players;

        public ICommand ShowPlayerFormCommand { get; }


        public PlayerListViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            _players = new ObservableCollection<PlayerViewModel>();

            ShowPlayerFormCommand = new ShowPlayerFormCommand(newPLayerFormStore);

            _playersManager = playersManager;

            UpdatePlayerList();
        }

        public void UpdatePlayerList()
        {
            _players.Clear();
            List<Player> playerList = _playersManager.GetPlayers();

            if (playerList != null)
            {
                foreach (Player player in playerList)
                {
                    PlayerViewModel playerViewModel = new PlayerViewModel(player, this, _playersManager);
                    _players.Add(playerViewModel);
                }
            }
        }
    }
}
