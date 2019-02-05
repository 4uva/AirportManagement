using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{

    public class Departure// what's is going on in line 21-22?
    {

        //view of the airline flight information about arrivals and departures
        // date and time, flight number, city/ port of
        //arrival(departure),      
        // terminal, flight status(check-in, gate closed,
        //arrived, departed at, unknown, canceled, expected at, delayed, in flight,gate)  

        public DateTimeOffset ScheduledDepareDateandTime { get;}
        public DateTimeOffset ActualDepartureDateandTime { get; set; }
        public Airport AssignedDepartureAirport { get; }
        public Airport UpdatedDepartureAirport { get; set; }
        public Terminal AssignedDepartureTerminal{ get; }
        public Terminal UpdatedDepartureTerminal{ get; set; }
        public Gate AssignedDepartureGate{ get; }
        public Gate UpdatedDepartureGate{ get; set; }
    }
}

