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
     
        { const string a = "a";
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
                  return UserChoice.Delete ;
                   
                case d:
                return   UserChoice.Cancel ;
                    
                default:
                  return UserChoice.Irrelevant ;
                   
            }
           
        }
    }
}

