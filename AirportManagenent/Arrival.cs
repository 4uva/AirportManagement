using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement
{
    class Arrival : Flight
    {
        readonly DateTimeOffset ScheduledArrivalDateandTime;
        DateTimeOffset ActualArrivalDateandTime;
        readonly Airport AssignedArrivalAirport;
        Airport UpdatedArrivalAirport;
        readonly Terminal AssignedArrivalTerminal;
        Terminal UpdatedArrivalTerminal;
        readonly Gate AssignedArrivalGate;
        Gate UpdatedArrivalGate;
      
    }
}
