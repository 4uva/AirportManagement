using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    class AirportListViewModel : ViewModel
    {
        public AirportListViewModel(All all)
        {
            foreach (var airport in all.Airports)
            {
                AirportViewModel airportViewModel = new AirportViewModel(airport);
                Airports.Add(airportViewModel);
                FilteredAirports.Add(airportViewModel);
                filteredAirportsSet.Add(airportViewModel);
            }
        }

        public ObservableCollection<AirportViewModel> Airports { get; } =
            new ObservableCollection<AirportViewModel>();
        public ObservableCollection<AirportViewModel> FilteredAirports { get; } =
            new ObservableCollection<AirportViewModel>();
        // for fast searching
        HashSet<AirportViewModel> filteredAirportsSet = new HashSet<AirportViewModel>();

        string filter;
        public string Filter
        {
            get => filter;
            set
            {
                if (Set(ref filter, value))
                    ApplyFilter(value);
            }
        }

        void ApplyFilter(string filter)
        {
            // add airports which are not in the list
            foreach (var airport in Airports)
            {
                bool isInOldFilteredList = filteredAirportsSet.Contains(airport);
                bool mustBeInFilteredListNow = CheckFilter(airport, filter);
                if (isInOldFilteredList && !mustBeInFilteredListNow)
                {
                    FilteredAirports.Remove(airport);
                    filteredAirportsSet.Remove(airport);
                }
                else if (!isInOldFilteredList && mustBeInFilteredListNow)
                {
                    FilteredAirports.Add(airport);
                    filteredAirportsSet.Add(airport);
                }
            }
        }

        bool CheckFilter(AirportViewModel airport, string filter)
        {
            if (filter == null || filter == "")
                return true;

            // тут у нас есть непустой фильтр
            return airport.Name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1 ||
                airport.LocationName.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1;
        }
    }
}
