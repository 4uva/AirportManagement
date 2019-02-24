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
    //    аргументы protected override void OnStartup(StartupEventArgs e)  используем
    //    потому что у перекрытой функции должна быть в точности такая же сигнатура,
    //    как и у перекрываемой(edited), а раз у перекрываемой функции передаётся
    //   параметр такого типа, то и нам нужно использовать его не обязательн
    //    но обязательно передать базовой функции


        protected override void OnStartup(StartupEventArgs e)//поясни Raises the Startup event.
        {
            base.OnStartup(e);
            var repository = new Repository(); // TODO: не грузить базу в UI-потоке мы создаём репозиторий
            var listViewModel = new AirportListViewModel(repository);//создаём ViewModel списка аэропортовr 2
            var window = new MainWindow() { DataContext = listViewModel }; //создаём главное окно, и прикрепляем к нему ViewModel
            window.Show();//говорим окну, «покажись!»
        }
    }
}
