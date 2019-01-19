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
            // Constructor invocation for this object is not relevant anymore
            All all = WriterReader.Read();
            AirportPresentation airportPresentation = new AirportPresentation();
            Menu menu = new Menu();

            while (true)
            {
                UserChoice userchoice = menu.Run();
                if (userchoice == UserChoice.Add)
                {
                    Console.WriteLine("Please add an Airport");
                    string userInput = Console.ReadLine();
                    all.AddAirport(userInput);
                }

                //если юзер выбрал удалить
                if (userchoice == UserChoice.Delete)
                {
                    //просим ввести аэропорт частично
                    Console.WriteLine("Enter part of airport's name");
                    //читаем ввод
                    string airportPartialName = Console.ReadLine();
                    //создаем список аэропортов на основе вызова функции фильтрации
                    List<Airport> filteredAirports = 
                        all.GetFilteredByPartialLocationAirports(airportPartialName);
                    //если длина списка больше 1
                    if (filteredAirports.Count > 1)
                    {
                        //если юзер выводим сообщение нашли такие аэропорты
                        Console.WriteLine("Found airports:");
                        //обращаемся к слою презентация и выводим аэропорты
                        airportPresentation.Output(filteredAirports);
                        //просим ввести больше букв или номер аэропорта в списке
                        Console.WriteLine("Enter a bigger part of airport's name " +
                            "or number in the list above");

                        //читаем ввод юзера и записываем переменную строку
                        string indexOrSubstring = Console.ReadLine();
                        //проверяем или введенная строка не является число,
                        //переменная выхолит со значением, а вхдит не с чем
                        if (int.TryParse(indexOrSubstring, out int index)) 
                        {
                            //проверяем, чтоб индекс был в списке
                            if (index < filteredAirports.Count  && index >= 0);
                            {
                                Airport userSelectedAirport = filteredAirports[index];
                                Console.WriteLine("Identified airport, " + userSelectedAirport.Location.Name + "enter d for delete or enter for cancel");
                            } 

                        
                            //   
                        }
                    }
                    //если индекса нет в списке выводим на экран
                    //НУЖНО ПРОПИСАТЬ УСЛОВИЕвыводим на экран  
                   
                    Console.WriteLine("The airport index is  irrelevant  Please try again or cancel deletion");
                    //если аэропорта  нет в списке 
                    //НУЖНО ПРОПИСАТЬ УСЛОВИЕвыводим на экран
                    Console.WriteLine("Airport is not in a list. Please try again or cancel deletion");
                    //если аэропорт - в списке 
                    //выводим на экран  
                    Console.WriteLine("Identified airport Budapest, enter d for delete or enter for cancel");
                    string userInput = Console.ReadLine();//считываем ввод юзера и прописывес механизм удаления
                    Console.WriteLine("Deletion canceled");
                    Console.WriteLine("Enter a for add, b for edit, c for cancel, d for deleted");
                    Console.WriteLine("Enter part of airport's name");
                    string userInputSelected = Console.ReadLine();
                    Console.WriteLine("Identified airport Budapest, enter d for delete or enter for cancel");
                    Console.WriteLine("Airport Budapest successfully deleted ");                 
                }
                // 3 варианта:
                // 1) много аэропортов, выводим их все, теперь запрашиваем индекс или подстроку.
                //    если получили индекс:
                //      * если индекс подходит для списка, берём по индексу
                //        аэропорт — он найден.
                //      * если не подходит, пишем, что индекс неправильный,
                //        и запрашиваем другую подстроку (как в пункте 2),
                //        фильтруем по ней и снова три варианта
                //    если подстроку, опять фильтруем по ней и три варианта
                // 2) ноль аэропортов. запрашиваем другую подстроку, фильтруем по ней
                //    и снова три варианта
                // 3) один аэропорт — он найден


                //-> enter a for add, b for edit, c for cancel, d for delete
                //<- d
                //-> enter part of airport's name
                //<- bu
                //-> found airports:
                //-> 1. Budapest
                //-> 2. Bucharest
                //-> enter a bigger part of airport's name or number in the list above
                //-> 1
                //-> Identified airport Budapest, enter d for delete or enter for cancel
                //<- (enter)
                //<- deletion canceled
                //-> enter a for add, b for edit, c for cancel, d for delete
                //<- d
                //-> enter part of airport's name
                //<- buda
                //-> Identified airport Budapest, enter d for delete or enter for cancel
                //<- d
                //-> Airport Budapest successfully deleted

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
