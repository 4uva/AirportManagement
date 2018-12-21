using System;

public class Departure
{

    //view of the airline flight information about arrivals and departures
    // date and time, flight number, city/ port of
    //arrival(departure),      
    // terminal, flight status(check-in, gate closed,
    //arrived, departed at, unknown, canceled, expected at, delayed, in flight,gate)  

    readonly DateTimeOffset ScheduledDateandTime;
    DateTimeOffset RealDateandTime;
    readonly string FlightNumber;
    readonly Airport PlanedAirport;
    Airport RealDestinationAirport;  
    readonly Terminal AssignedTerminal;
    Terminal RealTerminal;
    readonly Gate AssignedGate;
    Gate RealGate;
    enum FlightStatus; 

       
    
}
