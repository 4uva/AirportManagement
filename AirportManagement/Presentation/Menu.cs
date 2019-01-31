using System;

namespace AirportManagement.Presentation
{
    class Menu
    {
        public void DisplayGreeting()
        {
            Console.WriteLine("Hi! This is admin panel. ");            
        }
        
        public void DisplayPrompt()
        {
            Console.WriteLine(
              " You could  " +
              "add airport - press a, " +
              " update - b, " +
              "delete - d, " + "to cancel operation -c " +
              "Please make your choice"
            );
        }

        public UserChoice IdentifyInput(string UserInput)//вот откуда эта 
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";
            const string d = "d";

            switch (UserInput)
            {
                case a:
                    return UserChoice.Add;
        //  public void DisplayPromptAddAirportAgain()//    TODO LIST
        //{
        //    Console.WriteLine(
        //      "If you need to  add one more Airport - press Enter, 
         //     to cancel operation  press Esc " +
        //      " update - b, " +
        //      "delete - d, " + "to cancel operation -c " +
        //      "Please make your choice"
        //    );
        //}
                case b:
                    return UserChoice.Update;

                case c:
                    return UserChoice.Cancel;

                case d:
                    return UserChoice.Delete;

                default:
                    return UserChoice.Irrelevant;
            }
        }

        public UserChoice Run()
        {
            DisplayPrompt();
            string UserInput = Console.ReadLine();//вот завели переменную
            UserChoice userChoice = IdentifyInput(UserInput);//вот положили ее в параметр
            return userChoice;
        }
    }
}
