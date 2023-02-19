using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class AddXPCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly PlayersManager _playersManager;

        public AddXPCommand(PlayerViewModel playerViewModel, PlayerListViewModel playerListViewModel, PlayersManager playersManager)
        {
            _playerViewModel = playerViewModel;
            _playerListViewModel = playerListViewModel;
            _playersManager = playersManager;

            _playerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.XP_Input))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasXP = !string.IsNullOrEmpty(_playerViewModel.XP_Input);

            return HasXP && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                int playerXP = int.Parse(_playerViewModel.XP_Input);

                _playersManager.AddXpToPlayerWithId(_playerViewModel.ID, playerXP);

                _playerListViewModel.UpdatePlayerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
