using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StudentDatabase.ViewModels;
namespace StudentDatabase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();
            mainWindow.DataContext = new ViewModel();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
