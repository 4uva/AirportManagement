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

        public UserChoice Modify(string UserInput)//вот откуда эта 
                                                  //функция берет значение UserInput
     
        { const string a = "a";
            const string b = "b";
            const string c = "c";
            const string d = "d";
            

            switch (UserInput)
            {
                case a:
                   ;
                    break;
                case b:
                  ;
                    break;
                case c:
                   ;
                    break;
                case d:
                    ;
                    break;
                default:
                    Console.WriteLine("Wrong choice. Please try again."); ;
                    break;
            }
            return UserChoice;
        }
    }
}

