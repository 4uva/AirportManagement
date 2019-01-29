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

        public void Output(List<Airport> Airports)
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
            {
                for (int index = 0; index < Airports.Count; index++)// non idioma - for (int index = 0; index <=Airports.Count -1; index++
                {
                    Console.WriteLine (index); 
                    Airport airport = Airports[index];
                }
            }

        }
        
    }
}
