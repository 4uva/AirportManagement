using System;

namespace AirportManagement.Presentation
{
    class Menu
    {
        public void DisplayPrompt()
        {
            Console.WriteLine(
              "Hi! This is admin panel. You could  " +
              "add airport - press a, " +
              " update - b, " +
              "delete - d, " + "to cancel operation -c " +
              "Please make your choice"
            );
        }

        public UserChoice IdentifyInput(string UserInput)//вот откуда эта 
                                                         //функция берет значение UserInput
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";
            const string d = "d";

            switch (UserInput)
            {
                case a:
                    return UserChoice.Add;

                case b:
                    return UserChoice.Update;

                case c:
                    return UserChoice.Delete;

                case d:
                    return UserChoice.Cancel;

                default:
                    return UserChoice.Irrelevant;
            }
        }

        public void DisplayInputPrompt(UserChoice userChoice)
        //если юзер хочет добавить аэропорт, 
        //то нам нужно запросить имя аэропорта, 
        //прочитать его и добавить
        {
            if (userChoice == UserChoice.Add)
            {
                Console.WriteLine("Please add an Airport");

            }
            if (userChoice == UserChoice.Update)
            {
                Console.WriteLine("Please update an Airport");

            }
            if (userChoice == UserChoice.Update)
            {
                Console.WriteLine("Please update an Airport");

            }
            if (userChoice == UserChoice.Cancel)
            {
                Console.WriteLine("Please choose other option");

            }
            if (userChoice == UserChoice.Delete)
            {
                Console.WriteLine("Please delete an Airport");

            }
            if (userChoice == UserChoice.Irrelevant)
            {
                Console.WriteLine("Please try again");
            }
             ;
            //eсли юзер хочет удалить аэропорт, то нам нужно
            // вывести список, запросить номер или имя, и удалить его
            //а если хочет переименовать, то вывести список, запросить 
            //номер или имя, запросить новое имя, и присвоить   
        }

        public UserChoice Run()
        {
            DisplayPrompt();
            string UserInput = Console.ReadLine();
            UserChoice userChoice = IdentifyInput(UserInput);
            return userChoice;
        }
    }
}

