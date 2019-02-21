using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AirportManagement.Data;
using AirportManagement.WPF.VM;

namespace AirportManagement.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var all = new All(); // TODO: не грузить базу в UI-потоке
            var listViewModel = new AirportListViewModel(all);
            var window = new MainWindow() { DataContext = listViewModel };
            window.Show();
        }
    }
}
