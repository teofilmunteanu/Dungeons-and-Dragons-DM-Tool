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
        private readonly NewPLayerFormStore _newPLayerFormStore;


        public App()
        {
            _newPLayerFormStore = new NewPLayerFormStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_newPLayerFormStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
