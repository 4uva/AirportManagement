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
              "delete - c, " + "to cancel operation -d " + 
              "Please make your choice"
            );
        }

        public string Modify(string UserInput)//вот откуда эта 
                                              //функция берет значение UserInput
        {
            const string a = "a";//теперь относительно а, 
                                   //в UserInput а -это строка, а тут а -это имя 
                                   //это совершенно разные вещи и как их связать
                                   //непонятно
            const string b = "b";
            const string c = "c";
            const string e = "e";

            switch (UserInput)
            {
                case a:
                    Console.WriteLine("Add");
                    break;
                case b:
                    Console.WriteLine("Update");
                    break;
                case c:
                    Console.WriteLine("Cancel");
                    break;
                case e:
                    Console.WriteLine("Wrong choice. Please try again.");
                    break;
                default:
                    Console.WriteLine("Delete");
                    break;
            }
            return UserInput;
        }
    }
}

