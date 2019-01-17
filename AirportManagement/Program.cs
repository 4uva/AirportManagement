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

            while (true)
            {
                UserChoice userchoice = menu.Run();
                if (userchoice == UserChoice.Add)
                {
                    // и выдаёт приглашение ввести аэропорт
                    Console.WriteLine("Please add an Airport");
                    //5) программа читает аэропорт у юзера(где это будет в коде ?), юзер ввёл `"Жуляны"` `menu Programs`
                    string userInput = Console.ReadLine();

                    //6) программа вызывает `all.AddAirport`, передавая введённое имя(очевидно, в Main, потому что больше ни у кого нету нашего `All`)
                    all.AddAirport(userInput);
                }

                if (userchoice == UserChoice.Delete)
                {
                    //-> enter a for add, b for edit, c for cancel, d for delete
                    //<- d
                    //-> enter part of airport's name
                    //<- bu
                    //-> found airports:
                    //-> 1. Budapest
                    //-> 2. Bucharest
                    //-> enter a bigger part of airport's name or number in the list above
                    //<- 1
                    //-> Identified airport Budapest, enter d for delete or enter for cancel
                    //<- (enter)
                    //<- deletion canceled
                    //-> enter a for add, b for edit, c for cancel, d for delete
                    //<- d
                    //-> enter part of airport's name
                    //<- buda
                    //-> Identified airport Budapest, enter d for delete or enter for cancel
                    //<- d
                    //<- airport Budapest successfully deleted                    
                }

                if (userchoice == UserChoice.Irrelevant)
                {
                    //4) программа видит, что юзер выбрал добавить,
                    // и выдаёт приглашение ввести аэропорт
                    Console.WriteLine("Wrong choice. Please try again");
                }

                if (userchoice == UserChoice.Cancel)
                {
                    break;
                }
            }
        
            //7)вызов функции ппроисхдит у объекта,
            // 8)в аргумент  кладется вызов свойства у объекта классса
            airportPresentation.Output(all.Airports);
          //DisplayPromptAddAirportAgain - ToDo list to implement
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
