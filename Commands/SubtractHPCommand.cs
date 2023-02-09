using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SubtractHPCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly PlayersManager _playersManager;

        public SubtractHPCommand(PlayerViewModel playerViewModel, PlayerListViewModel playerListViewModel, PlayersManager playersManager)
        {
            _playerViewModel = playerViewModel;
            _playerListViewModel = playerListViewModel;
            _playersManager = playersManager;

            _playerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.HP_Input))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasHP = !string.IsNullOrEmpty(_playerViewModel.HP_Input);

            return HasHP && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                int damage = int.Parse(_playerViewModel.HP_Input);

                int dmgResult = _playersManager.DamagePlayerWithId(_playerViewModel.ID, damage);
                if (dmgResult == 2)
                {
                    MessageBox.Show(_playerViewModel.Name + " has died!");
                }
                else if (dmgResult == 1)
                {
                    MessageBox.Show(_playerViewModel.Name + " is unconscious!");
                }

                _playerListViewModel.UpdatePlayerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
