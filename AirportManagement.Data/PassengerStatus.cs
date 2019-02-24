using System;

namespace AirportManagement.Data
{
    enum PassengerStatus
    { 
        Notregistred,
        Checkin,
        OnGate,
        Boarding,
        RefusedBoarding,
        InFlight,
        Landed,
        LatedOnBoard,
        Overbooked,
        InTransit
    }
}
