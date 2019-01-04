using System;
using System.Collections.Generic;
using System.Text;

namespace AirportManagement.Presentation
{
    class Menu
    { 

         public  string Modify(string UserInput)
        {
            const string a = "Add";
            const string b = "Update";
            const string c = "Cancel";
            const string e = "Unrecognized";
             Console.WriteLine(
                "There is a command list. " +
                "To add airport - press a, " +
                "to update - b, " +
                "to delete - c"+ "to cancel operation -d");

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
