using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagenent
{

    public class Departure
    {

        //view of the airline flight information about arrivals and departures
        // date and time, flight number, city/ port of
        //arrival(departure),      
        // terminal, flight status(check-in, gate closed,
        //arrived, departed at, unknown, canceled, expected at, delayed, in flight,gate)  

        readonly DateTimeOffset ScheduledDepareDateandTime;
        DateTimeOffset UpdatedDepartureDateandTime;
        readonly Airport PlanedDepartureAirport;
        Airport UpdatedDepartureAirport;
        readonly Terminal AssignedDepartureTerminal;
        Terminal UpdatedDepartureTerminal;
        readonly Gate AssignedDepartureGate;
        Gate UpdatedDepartureGate;
    }
}

