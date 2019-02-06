using System;
using System.Collections.Generic;
using AirportManagement.Data;
namespace AirportManagement.Presentation
{
    class AirportOnScreen
    {
        public AirportOnScreen()
        {
        }
        
        public void HeaderOutput()
        {
            Console.WriteLine("Please look at airport list below");
            Console.WriteLine("Airports");
        }

        public void Output(IEnumerable<Airport> Airports)
        {
            foreach (Airport value in Airports)// in every type element value in variable 
            {
                Output(value);// 
            }
        }

        public void Output(Airport airport)//output only 1 Airport
        {
            var a = airport.Location;
            var b = a.Name;//можно закомментировать
            Console.WriteLine(b);//Console.WriteLine(airport.Location.Name) or `a.Name`,
        }

        public void OutputIndexed(List<Airport> Airports)
        {
            // non idiomatic - for (int index = 0; index <= Airports.Count -1; index++)
            for (int index = 0; index < Airports.Count; index++)
            {
                Airport airport = Airports[index];
                Console.WriteLine($"{index + 1}. {airport.Location.Name}");
            }
        }
    }
}
