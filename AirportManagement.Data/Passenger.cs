using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
    class Passenger
    {
        string PassengerFamilyName { get; set; }
        string PassengerName { get; set; }
        int PassengerAge { get; set; }
        Passenger Tariff { get; set; }
        Airport PassengerDeparturePoint { get; set; }
        Airport PassengerArrivalPoint { get; set; }
        public int Id { get; set; }
        public int FlightId { get; set; }
        private PassengerStatus current = PassengerStatus.Checkin;
    }
}
