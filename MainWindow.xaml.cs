using CefSharp.Wpf;
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
            this.imageWebBrowser.Source = new Uri(String.Format("file:///{0}/Resources/DMSCreen.png", curDir));
        }

        private void HomePage(object sender, RoutedEventArgs e)
        {
            ChromiumWebBrowser browser = BrowserTab.FindName("InternetBrowser") as ChromiumWebBrowser;
            browser.Address = "https://www.google.com/";
        }
    }
}
