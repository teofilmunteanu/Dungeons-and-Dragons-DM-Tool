using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class PlayerListViewModel : ViewModelBase
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        private readonly ObservableCollection<PlayerViewModel> _players;
        private readonly PlayersManager _playersManager;

        public ObservableCollection<PlayerViewModel> Players => _players;


        private PlayerViewModel? selectedPlayer = null;
        public PlayerViewModel? SelectedPlayer
        {
            get => selectedPlayer;
            set
            {
                SetField(ref selectedPlayer, value);

                IsPlayerSelected = SelectedPlayer != null ? true : false;
            }
        }

        private bool isPlayerSelected = false;
        public bool IsPlayerSelected
        {
            get => isPlayerSelected;
            set => SetField(ref isPlayerSelected, value);
        }


        public ICommand ShowPlayerFormCommand { get; }


        public PlayerListViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            _players = new ObservableCollection<PlayerViewModel>();

            _playersManager = playersManager;

            ShowPlayerFormCommand = new ShowPlayerFormCommand(newPLayerFormStore);

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

        public void UpdatePlayerProperties()
        {

        }
    }
}
