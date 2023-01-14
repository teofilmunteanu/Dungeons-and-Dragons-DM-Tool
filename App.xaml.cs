﻿using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Services;
using Deez_Notes_Dm.Stores;
using Deez_Notes_Dm.ViewModels;
using System.Windows;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly PlayersManager _playersManager;
        private readonly NewPLayerFormStore _newPLayerFormStore;

        public App()
        {
            PlayerCreatorService playerCreatorService = new PlayerCreatorService();
            PlayerProviderService playerProviderService = new PlayerProviderService();
            PlayerUpdateService playerUpdateService = new PlayerUpdateService();
            _playersManager = new PlayersManager(playerProviderService, playerCreatorService, playerUpdateService);

            _newPLayerFormStore = new NewPLayerFormStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_playersManager, _newPLayerFormStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
