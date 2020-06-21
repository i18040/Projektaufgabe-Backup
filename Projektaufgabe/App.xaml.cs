using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Projektaufgabe.Controllers;
using Projektaufgabe.Views;

namespace Projektaufgabe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var login = new LoginController();
            if (login.Initialize())
            {
                var user = login.CurrentUser;
                var mainWindow = new MainWindowController();
                mainWindow.CurrentUser = user;
                mainWindow.Initialize();
                Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
                Current.MainWindow = mainWindow.mView;
            }
        }
    }
}
