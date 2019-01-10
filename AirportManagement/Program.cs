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
            UserChoice userchoice =menu.IdentifyInput(UserInput);
            Console.ReadLine();
           airportPresentation.DisplayInputPrompt();
         //4) программа видит, что юзер выбрал добавить,
            // и выдаёт приглашение ввести аэропорт (где это будет в коде?)`
            // AirPortPresentation layor нужна ли новая функция, или
            // мы можем вложить это приглашение в функцию DisplayPrompt()- menu class`
           // airportPresentation.Output();
            //all.AddAirport (airportPresentation);
        }
    }
}
