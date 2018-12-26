using System;
using System.Collections.Generic;
using System.Text;

namespace AirportManagement.Data
{  //будущая бз добавить списки
   //аэропортов, полётов, и авиакомпаний
    class All
    {
      public  List<Airport> Airports { get; set; }

        static void Create()
        {
            var Airports = new List<Airport>()
            {
              new Airport()
            };
            //List<int> intList = new List<int>()
            //{
            //    10 + 1,
            //    20
            //};
        }
    }
}
