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
        protected override void OnStartup(StartupEventArgs e)//поясни Raises the Startup event.
        {
            base.OnStartup(e);
            var repository = new Repository(); // TODO: не грузить базу в UI-потоке
            var listViewModel = new AirportListViewModel(repository);//откуда взялся этот тип
            var window = new MainWindow() { DataContext = listViewModel }; //поясни всю строку MainWindow is automatically set with a reference to the first Window object to be instantiated in the AppDomain.
            window.Show();
        }
    }
}
