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
                for (int i = 0; i < Airports.Count - 1; i++)// in every type element value in variable 
                {
                    int[] index = Airports.Count - 1;//x-y+1

                    /* for (int i = 0; i < 991; i++)
                     {
                         int c = i + 10;
                         a[i] = c;
                     }*/
                    /* for (int c = 10; c <= 1000; c++)
                    {
                        int i = c - 10;
                        a[i] = c;
                    }*/
                }
            }

        }
        //public string AirportDatabaseCreation(string UserInput2)
        //{
        //    Console.WriteLine("Please add airport name");
        //}
    }
}
