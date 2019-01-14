using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportManagement.Data;
using AirportManagement.Data.Storage;
using AirportManagement.Presentation;

namespace AirportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            All all = WriterReader.Read();// Constructor invocation for this object is not relevant anymore
            AirportPresentation airportPresentation = new AirportPresentation();
            Menu menu = new Menu();
            UserChoice userchoice = menu.Run();

            //4) программа видит, что юзер выбрал добавить,
            if (userchoice == UserChoice.Add)
            {
                // и выдаёт приглашение ввести аэропорт
                Console.WriteLine("Please add an Airport");
                //5) программа читает аэропорт у юзера(где это будет в коде ?), юзер ввёл `"Жуляны"` `menu Programs`
                string userInput = Console.ReadLine();
                //6) программа вызывает `all.AddAirport`, передавая введённое имя(очевидно, в Main, потому что больше ни у кого нету нашего `All`)
                all.AddAirport(userInput);
            };
            //7)вызов функции ппроисхдит у объекта,
            // 8)в аргумент  кладется вызов свойства у объекта классса

            airportPresentation.Output(all.Airports);
            Console.ReadKey();

            //all.AddAirport (airportPresentation);

            //сли юзер хочет добавить аэропорт, 
            //то нам нужно запросить имя аэропорта, 
            //прочитать его и добавить
            //если юзер хочет удалить аэропорт, 
            //то нам нужно вывести список, запросить
            //номер или имя, и удалить его
            //а если хочет переименовать, 
            //то вывести список, запросить номер или имя, запросить новое имя, и присвоить

            WriterReader.Write(all);//статический метод вызывается у класса
            Console.ReadKey();
        }
    }
}
