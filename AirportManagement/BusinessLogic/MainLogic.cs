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
            while (filteredAirports.Count != 1)
            {
                if (filteredAirports.Count == 0)
                    Console.WriteLine("Found no airports. Please enter another part of airport name.");//49th lines 
                else
                {
                    airportOnScreen.OutputIndexed(filteredAirports);
                    Console.WriteLine("Enter a bigger part of airport's name or number in the list above ");
                }

                string indexOrSubstring = Console.ReadLine();

                // checking if input string is a number for the case of big list
                if (filteredAirports.Count > 1 && int.TryParse(indexOrSubstring, out int index))
                {
                    // now try to delete airport by index
                    // if index fits into the list index range...
                    if (index < filteredAirports.Count && index >= 0)
                    {
                        // remove the airpots it points to and leave function
                        Airport userSelectedAirport = filteredAirports[index];
                        ProcessDeleteAirport(userSelectedAirport);
                        return;
                    }
                    else
                    {
                        // otherwise inform the user and continue iterating
                        Console.WriteLine("Wrong choice. There is no airports enlisted " +
                            "Please try again.");
                    }
                }
                else // for the case of empty list we don't consider index
                {
                    filteredAirports = all.GetFilteredByPartialLocationAirports(indexOrSubstring);//on screen filtred list
                }
            }

            ProcessDeleteAirport(filteredAirports[0]);
        }

        void ProcessDeleteAirport(Airport airport)//1 is here
        {
            Console.WriteLine("Identified airport, " + airport.Location.Name);
            Console.WriteLine("enter d for delete or enter for cancel");
            //нашлиns  аропорт просим юзера /
            //удалилить или отменить операцию удаления
            string deletion = Console.ReadLine();

            //если юзер выбрал удалить
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

        void ProcessIrrelevant()
        {
            Console.WriteLine("Wrong choice. Please try again");
        }

        public StepResult RunStep()
        {
            // Airports
            airportOnScreen.HeaderOutput();
            airportOnScreen.Output(all.Airports);
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
