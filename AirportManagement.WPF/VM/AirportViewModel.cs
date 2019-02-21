using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    public class AirportViewModel : ViewModel
    {
        public AirportViewModel(Airport airport)
        {
            this.airport = airport;
            name = airport.Name;
            locationName = airport.Location.Name;
        }

        string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        string locationName;
        public string LocationName
        {
            get => locationName;
            set => Set(ref locationName, value);
        }

        Airport airport;
    }
}