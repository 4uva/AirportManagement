using System;
using System.Collections.Generic;
using AirportManagement.Data;
namespace AirportManagement.Presentation
{
    class AirportPresentation
    {
        public AirportPresentation()
        {
        }

        public void Output(List<Airport> Airports)
        {
            string Header = "Airports";
            Console.WriteLine(Header);

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

        //public string AirportDatabaseCreation(string UserInput2)
        //{
        //    Console.WriteLine("Please add airport name");
        //}
    }
}
