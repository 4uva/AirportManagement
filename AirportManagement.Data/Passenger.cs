using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
   
    class Passenger
    {
        public string PassengerFamilyName { get; set; }
        public string PassengerFirstName { get; set; }
        DateTime PassengerDateOfBirth { get; set; }
        public string TravelDocumentNumber { get; set; }
        public string Nationality { get; set; }
        public Sex Sex{ get; set; }
        public SeatClass SeatClass { get; set; }
        public Flight Flight{ get; set; }
        private PassengerStatus current = PassengerStatus.Checkin;
       
        public int Id { get; set; }
    }
}
