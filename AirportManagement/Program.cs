using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportManagement.Data;
using AirportManagement.Presentation;

namespace AirportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            All all = new All();
            DataonScreen dataonScreen = new DataonScreen();
            //dataonScreen.DataOutput(all.Airports);
            Menu menu = new Menu();
            string prompt = Console.ReadLine();
            menu.DisplayPrompt(prompt);
            Console.ReadKey();
            string UserInput = Console.ReadLine();
            menu.Modify(UserInput);
            Console.ReadKey();

            // all.Create(); вызова функции Create 
        }
    }
}
