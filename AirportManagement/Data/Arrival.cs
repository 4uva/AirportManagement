using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
    class Arrival : Flight
    {
        public  DateTimeOffset ScheduledArrivalDateandTime{ get; }
        public DateTimeOffset ActualArrivalDateandTime{ get; set; }
        public Airport AssignedArrivalAirport{ get;  }
        public Airport UpdatedArrivalAirport{ get; set; }
        public  Terminal AssignedArrivalTerminal{ get;  }
        public Terminal UpdatedArrivalTerminal{ get; set; }
        public  Gate AssignedArrivalGate{ get;  }
        public Gate UpdatedArrivalGate{ get; set; }
      
    }
}
