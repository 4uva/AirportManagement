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
           DataonScreen dataonScreen  = new DataonScreen();
            dataonScreen.DataOutput(all.Airports);
            Console.ReadKey();
            Menu menu = new Menu();
            string UserInput = Console.ReadLine();
            menu.Modify( UserInput);

            // all.Create(); вызова функции Create 
        }
    }
}
