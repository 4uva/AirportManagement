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

            menu.Run();
            //UserChoice userChoice =
            menu.DisplayInputPrompt(userChoice);
            //userchoice.тут нужно вызвать функцию  у объекта

            //4) программа видит, что юзер выбрал добавить,
            // и выдаёт приглашение ввести аэропорт (где это будет в коде?)`
            // AirPortPresentation layor нужна ли новая функция, или
            // мы можем вложить это приглашение в функцию DisplayPrompt()- menu class`
            // airportPresentation.Output();
            //all.AddAirport (airportPresentation);

            //сли юзер хочет добавить аэропорт, 
            //то нам нужно запросить имя аэропорта, 
            //прочитать его и добавить
            //если юзер хочет удалить аэропорт, 
            //то нам нужно вывести список, запросить
            //номер или имя, и удалить его
            //а если хочет переименовать, 
            //то вывести список, запросить номер или имя, запросить новое имя, и присвоить
        }
    }
}
