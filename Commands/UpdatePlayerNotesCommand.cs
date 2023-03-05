using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class UpdatePlayerNotesCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;
        private readonly PlayersManager _playersManager;

        public UpdatePlayerNotesCommand(PlayerViewModel playerViewModel, PlayersManager playersManager)
        {
            _playerViewModel = playerViewModel;
            _playersManager = playersManager;
        }


        public override void Execute(object? parameter)
        {
            try
            {
                _playersManager.SetNotesToPlayerWithId(_playerViewModel.ID, _playerViewModel.Notes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
