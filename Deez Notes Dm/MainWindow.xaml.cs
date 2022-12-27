using System;
using System.IO;
using System.Windows;

namespace Deez_Notes_Dm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser.Source = new Uri(String.Format("file:///{0}/Resources/DMSCreen.png", curDir));


            //reinitializeCombatants();
        }
        private void Button_Click_CloseModal(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_OpenModal(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_ShowPlayerForm(object sender, RoutedEventArgs e)
        {
            //this.NewPlayerForm.Visibility = Visibility.Visible;

            //ResetInputs();
        }
    }
}
