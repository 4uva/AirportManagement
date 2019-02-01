using System;
using System.Collections.Generic;
using System.Text;
using AirportManagement.Data;
using AirportManagement.Presentation;

namespace AirportManagement.BusinessLogic
{
    class MainLogic
    {
        public MainLogic(All all)
        {
            this.all = all;
            menu.DisplayGreeting();
        }
        
        void ProcessAdd()
        {
            Console.WriteLine("Please add an Airport");
            string userInput = Console.ReadLine();
            all.AddAirport(userInput);
        }

        void ProcessDelete()
        {
            //просим ввести аэропорт частично
             Console.WriteLine("Enter part of airport's name");
            //читаем ввод
            string airportPartialName = Console.ReadLine();
            // после прочтения может не создать список в строке 30
            //создаем список аэропортов на основе вызова функции фильтрации
            List<Airport> filteredAirports =
                all.GetFilteredByPartialLocationAirports(airportPartialName);

            // a) список аэропортов не обновляется в цикле, из-за чего выводится каждый раз одно и то же
            // b)проверить вывод отсортированого списка
            // c) с выводом одного аэропорта по идее проблем быть не должно

            // 3 варианта:
            while (filteredAirports.Count > 1)
            {
                Console.WriteLine("Found airports:");//НУЖНО ПОВТОРЯТЬ
                airportOnScreen.OutputIndexed(filteredAirports);//НУЖНО ПОВТОРЯТЬ                                                
                Console.WriteLine("Enter a bigger part of airport's name " +
                     "or number in the list above");//НУЖНО ПОВТОРЯТЬ
                string indexOrSubstring = Console.ReadLine();

                //проверяем или введенная строка не является число,
                //переменная выхолит со значением, а вхдит не с чем
                if (int.TryParse(indexOrSubstring, out int index))
                //проверили строка или число
                {
                    ProcessDeletebyIndex(index - 1, filteredAirports);
                    return;
                }
                else
                {
                    filteredAirports = all.GetFilteredByPartialLocationAirports(indexOrSubstring);
                }
            }

            if (filteredAirports.Count == 0)
            {
                // 2) ноль аэропортов. запрашиваем другую подстроку, фильтруем по ней
                //    и снова три варианта
                throw new NotImplementedException("Case when list contains no airports");
            }
            else
            {
                // 3) один аэропорт — он найден
                ProcessDeleteAirport(filteredAirports[0]);
            }
        }

        void ProcessDeleteAirport(Airport airport)//1 is here
        {
            Console.WriteLine("Identified airport, " +
                airport.Location.Name);
            Console.WriteLine("enter d for delete or enter for cancel");
            //нашлиns  аропорт просим юзера /
            //удалилить или отменить операцию удаления
            string deletion = Console.ReadLine();

            // if (userchoice == UserChoice.Delete)//если юзер выбрал удалить
            if (deletion == "d")
            {
                all.DeleteAirport(airport);
                Console.WriteLine(" Selected airport was sucessfully deleted");
            }
            else
            {
                Console.WriteLine("Deletion canceled");
            }
        }

        void ProcessDeletebyIndex2(int index, List<Airport> filteredAirports)
        {
            while (!(index < filteredAirports.Count && index >= 0)) // until in range
            {
                Console.WriteLine("Index is out of range, please correct");
                while (true) // until number is entered
                {
                    string indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                        break;
                    Console.WriteLine("Please input number");
                }
                index--; // adjust 1-based to 0-based
            }
            Airport userSelectedAirport = filteredAirports[index];
            ProcessDeleteAirport(userSelectedAirport);
        }

        void ProcessDeletebyIndex(int index, List<Airport> filteredAirports)
        {
            //проверяем, чтоб индекс был в списке
            if (index < filteredAirports.Count && index >= 0)
            {
                Airport userSelectedAirport = filteredAirports[index];
                ProcessDeleteAirport(userSelectedAirport);
            }
            else
            {
                while (index >= filteredAirports.Count)
                {
                                                                    
                    Console.WriteLine("Enter a bigger part of airport's name " +
                         "or number in the list above");//НУЖНО ПОВТОРЯТЬ
                        string indexOrSubstring = Console.ReadLine();
                    if (int.TryParse(indexOrSubstring, out  index  ))
                    {
                        ProcessDeletebyIndex(index - 1, filteredAirports);
                        return;
                    }

                      
                    Console.WriteLine("Wrong choice. Please Enter a bigger part of airport's name " +
                        "or number in the list above");
                    //проверяем или введенная строка не является число,
                    //переменная выхолит со значением, а вхдит не с чем
                  
                    //проверили строка или число
                    
                }
            }
        }

        void ProcessIrrelevant()
        {
            Console.WriteLine("Wrong choice. Please try again");
        }

        public StepResult RunStep()
        {
            // Airports
            airportOnScreen.HeaderOutput();
            airportOnScreen.Output( all.Airports);
            UserChoice userchoice = menu.Run();
            //это дублирующая логика только для слоя презентации 
            if (userchoice == UserChoice.Add)
                ProcessAdd();

            //если юзер выбрал удалить
            if (userchoice == UserChoice.Delete)
                ProcessDelete();

            if (userchoice == UserChoice.Irrelevant)
                ProcessIrrelevant();

            if (userchoice == UserChoice.Cancel)
                return StepResult.Exit;

            return StepResult.Continue;
        }

        //это поле, которое инициализируется ссылкой на экземпляр объекта
        private AirportOnScreen airportOnScreen = new AirportOnScreen();
        private Menu menu = new Menu();
        private All all;
    }
}
