﻿using MireWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MireWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginViewModel ViewModel { get { return DataContext as LoginViewModel; } }

        public LoginView()
        {
            InitializeComponent();
            //ChartGrid.SizeChanged += ChartGridOnSizeChanged;
            //SizeChanged += ChartGridOnSizeChanged;
            //Loaded += OnLoaded;
        }

        private void LoginControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
