using System;
using System.Collections.Generic;
using AirportManagement.Data;
namespace AirportManagement.Presentation
{
    class DataonScreen
    {
        public DataonScreen()
        {
        }
   
        public  void DataOutput(List<Airport> Airports)
        {
            string Header = "Airports";
            Console.WriteLine(Header);

            foreach  ( Airport value in Airports)// in every type element value in variable 
            { 
               Output(value);// 
            }
        }

        //void HeaderPresentation()
        //{
        //}
         void Output(Airport airport)//output only 1 Airport
         {  
             var a = airport.Location;
             var b = a.Name;//можно закомментировать
             Console.WriteLine(b);//Console.WriteLine(airport.Location.Name) or `a.Name`,
         }
    }
}
