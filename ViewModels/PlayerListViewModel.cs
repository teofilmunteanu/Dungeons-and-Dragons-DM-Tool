using Deez_Notes_Dm.Commands;
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

        public ObservableCollection<PlayerViewModel> Players => _players;

        public ICommand ShowPlayerFormCommand { get; }
        public ICommand LoadPlayersCommand { get; }

        public PlayerListViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            _players = new ObservableCollection<PlayerViewModel>();

            ShowPlayerFormCommand = new ShowPlayerFormCommand(newPLayerFormStore);

            UpdatePlayerList(playersManager.GetPlayers());
        }

        public void UpdatePlayerList(List<Player> playerList)
        {
            _players.Clear();

            if(playerList != null)
            {
                foreach (Player player in playerList)
                {
                    PlayerViewModel playerViewModel = new PlayerViewModel(player);
                    _players.Add(playerViewModel);
                }
            }
        }
    }
}
