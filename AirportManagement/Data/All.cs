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
            var airports0 = new List<Airport>()
            {
                new Airport(),
                new Airport(),
                new Airport(),
                new Airport()
            };

            //---------------------------------------

            var a = new Airport();
            //1)мы присвоили переменной а 
            //значение нового аэропорта
            var b = new Airport();
            var c = new Airport();
            var d = new Airport();
            var f = new Location();
            //2)мы присвоили переменной f 
            //значение локация
            var e = new Location();
            var g = new Location();
            var i = new Location();

            //мы присвоили полю                                                                         Аэропорта 
            //значение объекта типа Location, у которого есть поле `Name`
            a.Location = f;
            
            f.Name = "Florence";
            //3)мы обратились к полю Name
            //класса Location 
           
            e.Name = "Elabuga";
            
            g.Name = "Gatwick";
            
            i.Name = "Insbruk";




            var airports = new List<Airport>()
            {
              a, b, c, d//new Airport (),new Airport(), new Airport ()
            };

            //---------------------------------------

            var airports2 = new List<Airport>();
            airports2.Add(new Airport());
            airports2.Add(new Airport());
            airports2.Add(new Airport());
            airports2.Add(new Airport());

            //---------------------------------------

            var airports3 = new List<Airport>();//список на входе
            airports3.AddRange(new List<Airport>() { new Airport(), new Airport(), new Airport(), new Airport() });
            airports3.AddRange(new Airport[] { new Airport(), new Airport(), new Airport(), new Airport() });//массив на выходе
        }
    }
}
