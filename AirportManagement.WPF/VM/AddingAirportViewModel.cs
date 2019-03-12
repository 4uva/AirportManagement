using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.WPF.VM
{
    class AddingAirportViewModel : ViewModel, INotifyPropertyChanged
    {
        public string AirportName
        {
            get => airportName;
            set => Set(ref airportName, value);//присваивание свойству есть вызов сеттера
        }
        string airportName;
        public string AirportLocation
       
        {
            get => airportLocation;
            set => Set(ref airportLocation, value);//присваивание свойству есть вызов сеттера
        }

        string airportLocation;
    }
}
