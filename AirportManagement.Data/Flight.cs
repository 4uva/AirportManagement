using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
    class Flight
    {
        public string FlightNumber { get; set; }
        FlightStatus current = FlightStatus.Checkin;
        public int Id { get; set; }
    }
}
