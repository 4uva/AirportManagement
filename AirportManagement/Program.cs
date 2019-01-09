using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportManagement.Data;
using AirportManagement.Presentation;

namespace AirportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            All all = new All();
            AirportPresentation airportPresentation = new AirportPresentation();
            //airportPresentation.Output(all.Airports);
            Menu menu = new Menu();
            menu.DisplayPrompt();
            string UserInput = Console.ReadLine();
            menu.Modify(UserInput);
            Console.ReadKey();

            airportPresentation.Output();
            all.AddAirport (airportPresentation);
    
            //string UserInput2 = Console.ReadLine();
            //Console.ReadKey();
            //menu.AirportDatabaseCreation(UserInput2);

            // all.Create(); вызова функции Create 
        }
    }
}
