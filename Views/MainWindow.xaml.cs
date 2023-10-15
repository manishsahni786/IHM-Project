using System;
using System.Windows;
using MireWpf.ViewModels;

using System.Configuration;
using System.Globalization;

namespace MireWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel
        {
            get { return DataContext as MainWindowViewModel; }
            set { DataContext = value; }
        }

        public MainWindow()
        {
            // VERSION Normal
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
            // VERSION Chinoise ( Dé/Commenté le type en fonction de la langue )
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh");
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
        }
    }
}
