﻿using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.Commands
{
    public class CreatePlayerCommand : CommandBase
    {
        private readonly NewPlayerFormViewModel _newPlayerFormViewModel;
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly PlayersManager _playersManager;

        public CreatePlayerCommand(NewPlayerFormViewModel newPlayerFormViewModel, PlayerListViewModel playerListViewModel, PlayersManager playersManager)
        {
            _newPlayerFormViewModel = newPlayerFormViewModel;
            _playerListViewModel = playerListViewModel;
            _playersManager = playersManager;

            _newPlayerFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewPlayerFormViewModel.Name) ||
                e.PropertyName == nameof(NewPlayerFormViewModel.Race) ||
                e.PropertyName == nameof(NewPlayerFormViewModel.MainClass)) // || restul parametrilor
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasName = !string.IsNullOrEmpty(_newPlayerFormViewModel.Name);
            bool HasRace = !string.IsNullOrEmpty(_newPlayerFormViewModel.Race);
            bool HasClass = !string.IsNullOrEmpty(_newPlayerFormViewModel.MainClass);
            //restul param

            return HasName && HasRace && HasClass && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                int playerID = _playersManager.GetPlayers().Count;

                Speed speed = new()
                {
                    walk = int.Parse(_newPlayerFormViewModel.Speed),
                    fly = string.IsNullOrEmpty(_newPlayerFormViewModel.FlySpeed) ? 0 : int.Parse(_newPlayerFormViewModel.FlySpeed)
                };

                Stats baseStats = new()
                {
                    STR = int.Parse(_newPlayerFormViewModel.STR),
                    DEX = int.Parse(_newPlayerFormViewModel.DEX),
                    CON = int.Parse(_newPlayerFormViewModel.CON),
                    INT = int.Parse(_newPlayerFormViewModel.INT),
                    WIS = int.Parse(_newPlayerFormViewModel.WIS),
                    CHA = int.Parse(_newPlayerFormViewModel.CHA)
                };


                Player player = new Player(playerID,
                _newPlayerFormViewModel.Name,
                _newPlayerFormViewModel.Race,
                int.Parse(_newPlayerFormViewModel.HP),
                int.Parse(_newPlayerFormViewModel.AC),
                speed,
                baseStats,
                _newPlayerFormViewModel.MainClass,
                _newPlayerFormViewModel.InsightProficiency,
                _newPlayerFormViewModel.PerceptionProficiency,
                _newPlayerFormViewModel.InvestigationProficiency
                );

                _playersManager.AddPlayer(player);
                _playerListViewModel.UpdatePlayerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            _newPlayerFormViewModel.CancelCommand.Execute(null);
        }
    }
}
