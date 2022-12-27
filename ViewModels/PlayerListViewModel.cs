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

        public IEnumerable<PlayerViewModel> Players => _players;

        public ICommand ShowPlayerFormCommand { get; }

        public PlayerListViewModel(NewPLayerFormStore newPLayerFormStore)
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

            ShowPlayerFormCommand = new ShowPlayerFormCommand(newPLayerFormStore);
        }
    }
}
