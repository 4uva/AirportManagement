using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    class AddingAirportViewModel : AddingGeneric<Airport>
    {
        public AddingAirportViewModel()
        {
        }

        protected override Airport Save()
        {
            throw new NotImplementedException();
            // TODO: crteate through repository
        }

        protected override bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(AirportName) && !string.IsNullOrWhiteSpace(AirportLocation);
        }

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
