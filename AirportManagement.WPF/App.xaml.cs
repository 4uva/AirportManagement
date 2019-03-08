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
        Repository repository = new Repository();

        protected override void OnStartup(StartupEventArgs e)//поясни Raises the Startup event.
        {
            base.OnStartup(e);

            var listViewModel = new AirportListViewModel(repository);//создаём ViewModel списка аэропортовr 2
            var window = new MainWindow() { DataContext = listViewModel }; //создаём главное окно, и прикрепляем к нему ViewModel
            //если мы хотим, чтобы наш View - элемент отображал
            // (то есть, являлся _представлением_) какого - то VM - объекта
            //  (который представляет собой _контент_), то мы устанавливаем 
            ////DataContext'ом этого View-элемента (контрола) этот самый VM-объект
            //new Airport() аналог { DataContext = listViewModel  совершенно привычный инициализатор объекта:
            //{
            //    Name = airportName,
            //    Location = new Location
            //    {
            //        Name = locationName
            //    }
            //};
            window.Show();//говорим окну, «покажись!»
        }

        protected override void OnExit(ExitEventArgs e)
        {
            repository.Dispose();
            base.OnExit(e);
        }
    }
}
