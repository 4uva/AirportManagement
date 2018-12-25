using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
    class Flight
    {
        readonly string FlightNumber;
        FlightStatus current = FlightStatus.Checkin;
    }
}
