using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using NLog;




namespace MireWpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// 
    /// </summary>
    
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += OnDispatcherUnhandledException;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogManager.GetCurrentClassLogger().Debug(e.Exception);
        }
    }
}
