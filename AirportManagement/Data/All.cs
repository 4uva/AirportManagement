using System;
using System.Collections.Generic;
using System.Text;

namespace AirportManagement.Data
{  //будущая бз добавить списки
   //аэропортов, полётов, и авиакомпаний
    public class All
    {
        public All()//модификаторы, имя класса, 
                    //в скобках список аргументов
        {
            Create();//упоминать экземпляр класса нет необходимости
        }

        //поле r
        //All All2 { get; set; }  свойство
        public void Create()
        {
            var a = new Airport();
            //1)мы присвоили переменной а значение нового аэропорта
            var b = new Airport();
            var c = new Airport();
            var d = new Airport();

            var f = new Location();
            //2)мы присвоили переменной f значение локация
            var e = new Location();
            var g = new Location();
            var i = new Location();

            //мы присвоили полю                                                                         Аэропорта 
            //значение объекта типа Location, у которого есть поле `Name`
            a.Location = f;
            b.Location = e;
            c.Location = g;
            d.Location = i;

            f.Name = "Florence";
            //3)мы обратились к полю Name класса Location 
            e.Name = "Elabuga";
            g.Name = "Gatwick";
            i.Name = "Insbruk";

            /* var airports = new List<Airport>()
             {
                 a, b, c, d
                 //new Airport (), new Airport (), new Airport(), new Airport (r              a.Airport="Florence";gj
             };*/

            Airports = new List<Airport> { a, b, c, d };


        }
     



        public List<Airport> Airports { get; set; }
        

    }
}


//var airports0 = new List<Airport>()
//{
//    new Airport(),
//    new Airport(),
//    new Airport(),
//    new Airport()
//};
//---------------------------------------

//var airports2 = new List<Airport>();
//airports2.Add(new Airport());//в
//airports2.Add(new Airport());
//airports2.Add(new Airport());
//airports2.Add(new Airport());

////---------------------------------------

//var airports3 = new List<Airport>();//список на входе
//airports3.AddRange(new List<Airport>() { new Airport(), new Airport(), new Airport(), new Airport() });
//airports3.AddRange(new Airport[] { new Airport(), new Airport(), new Airport(), new Airport() });//массив на выходе
