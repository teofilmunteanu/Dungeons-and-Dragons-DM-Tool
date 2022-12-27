using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PlayerViewModel> _players;

        public IEnumerable<PlayerViewModel> Players => _players;

        public PlayerListViewModel()
        {
            _players = new ObservableCollection<PlayerViewModel>();

            PlayersManager pm = new PlayersManager();
            List<Player> playersList = pm.GetPlayers();

            if (playersList is not null)
            {
                foreach (Player p in playersList)
                {
                    _players.Add(new PlayerViewModel(p));
                }
            }
        }
    }
}
