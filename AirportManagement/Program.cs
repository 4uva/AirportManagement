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
                    Console.WriteLine("Enter part of airport's name");
                    //<- bu
                    string airportPartialName = Console.ReadLine();
                    // All all = WriterReader.Read();
                    List<Airport> filteredAirports =  all.GetFilteredByPartialLocationAirports(airportPartialName );
                    // 3 варианта:
                    // 1) много аэропортов, выводим их все, теперь запрашиваем индекс или подстроку.
                    if ( filteredAirports.Count >1)
                    {
                        Console.WriteLine("Found airports:");
                        airportPresentation.Output(filteredAirports);
                        Console.WriteLine("Enter a bigger part of airport's name or number in the list above");
                        string indexOrSubstring = Console.ReadLine();

                        /*
                            int index;
                            if (int.TryParse(s, out index)) { ... }

                            - - is the same as - -

                            if (int.TryParse(s, out int index)) { ... }
                                                    ^^^
                         */


                        if (int.TryParse(indexOrSubstring, out int index))
                        {
                            //можно пояснить 52 строку, мы вызываем функцию
                            /// у какого объекта
                            /// и на выходе или на входе при синтаксисе out int index
                            //мы получаем интовое значение

                        }

                    }
                    //    если получили индекс, берём по индексу аэропорт — он найден.
                    //    если подстроку, опять фильтруем по ней и три варианта
                    // 2) ноль аэропортов. запрашиваем другую подстроку, фильтруем по ней
                    //    и снова три варианта
                    // 3) один аэропорт — он найден

                    //-> found airports:
                    //-> 1. Budapest
                    //-> 2. Bucharest
                    //-> notfound airports:
                    Console.WriteLine("Airport is not in a list. Please try again or cancel deletion");
                    // -- only if list contains more than 1 airport --
                    //-> enter a bigger part of airport's name or number in the list above
                    
                    //<- 1
                    //тестируем, номер ли это, через TryParse
                    //если номер, у нас есть список, и в нём индексиеуем
                    //если не номер, то это подстрока, и она отправляется в слой данных
                    // -- here we have either number (and it implies one airport) --
                    // -- or another part of name (and it implies a list again) --
                    // -- of the list contains more than 1 item, we need to repeat the logic above --
                    Console.WriteLine("Enter a bigger part of airport's name or number in the list above");
                    // -- as soon as we have only one airport:
                    Console.WriteLine("Identified airport Budapest, enter d for delete or enter for cancel");
                    //-> Identified airport Budapest, enter d for delete or enter for cancel
                    //<- (enter)
                    Console.WriteLine("Deletion canceled");
                    //<- deletion canceled
                    Console.WriteLine("Enter a for add, b for edit, c for cancel, d for deleted");
                    //-> enter a for add, b for edit, c for cancel, d for delete
                    //<- d
                    Console.WriteLine("Enter part of airport's name");
                    //-> enter part of airport's name
                     string userInputSelected = Console.ReadLine();
                    //<- buda
                   Console.WriteLine("Identified airport Budapest, enter d for delete or enter for cancel");
                    //->Identified airport Budapest, enter d for delete or enter for cancel
                    //<- d
                    Console.WriteLine("Airport Budapest successfully deleted ");                 
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
