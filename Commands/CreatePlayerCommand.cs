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
        private readonly PlayersManager _playersManager;

        public CreatePlayerCommand(NewPlayerFormViewModel newPlayerFormViewModel, PlayersManager playersManager)
        {
            _newPlayerFormViewModel = newPlayerFormViewModel;
            _playersManager = playersManager;

            _newPlayerFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewPlayerFormViewModel.Name)) // || restul parametrilor
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasName = !string.IsNullOrEmpty(_newPlayerFormViewModel.Name);
            //bool HasRace = !string.IsNullOrEmpty(_newPlayerFormViewModel.Race);
            //bool HasClass = !string.IsNullOrEmpty(_newPlayerFormViewModel.MainClass);

            return HasName && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            int playerID = _playersManager.GetPlayers().Count - 1;
            Speed speed = new()
            {
                walk = _newPlayerFormViewModel.Speed,
                fly = _newPlayerFormViewModel.FlySpeed
            };

            Stats baseStats = new()
            {
                STR = _newPlayerFormViewModel.STR,
                DEX = _newPlayerFormViewModel.DEX,
                CON = _newPlayerFormViewModel.CON,
                INT = _newPlayerFormViewModel.INT,
                WIS = _newPlayerFormViewModel.WIS,
                CHA = _newPlayerFormViewModel.CHA
            };

            try
            {
                Player player = new Player(playerID,
                _newPlayerFormViewModel.Name,
                _newPlayerFormViewModel.Race,
                _newPlayerFormViewModel.HP,
                _newPlayerFormViewModel.AC,
                speed,
                baseStats,
                _newPlayerFormViewModel.MainClass,
                _newPlayerFormViewModel.InsightProficiency,
                _newPlayerFormViewModel.PerceptionProficiency,
                _newPlayerFormViewModel.InvestigationProficiency
                );

                _playersManager.AddPlayer(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}