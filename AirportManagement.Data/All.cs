using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Data
{
    //добавить списки, аэропортов, полётов, и авиакомпаний
    public class All : IDisposable
    {
        public Airport AddAirport(string locationName)
        // создали публичную функцию добавить аэропорт , котррая
        //возращает аэропорт и на вход получает имя аэропорта
        {
            var a = CreateAirport(locationName);
            //создали переменную и присвоили ей значение вызова 
            //функции с параметром локация аэропорта
            dbContext.Airports.Add(a);//добавили экземпляр аэропорта 
            //со значением фактического параметра а
            return a;
            //вернули значение фактического параметра
        }

        public void DeleteAirport(Airport airport)
        {   
            dbContext.Airports.Remove(airport);
        }

        Airport CreateAirport(string locationName)
        {
            var a = new Airport();//
            //1)мы присвоили переменной а значение нового аэропорта
            var f = new Location();//
            a.Location = f;
            f.Name = locationName;
            //2)мы присвоили переменной f значение локация var g = new Location();           
            //мы присвоили полю                                                                         Аэропорта 
            //значение объекта типа Location, у которого есть поле `Name`c.Location = g;
            //3)мы обратились к полю Name класса Location
            return a;//переменная умрет, а нам нужно сделать так,
            // чтоб эти данные а можно было записать в функции
        }

        public List<Airport> GetFilteredByPartialLocationAirports(string partialLocation)
        {//todo WHAT IS LINQ
            return Airports
                .Where(a => a.Location.Name.Contains(partialLocation, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(a => a.Location.Name)
                .ToList();
        }

        public void Dispose()
        {
            dbContext.SaveChanges();
            dbContext.Dispose();
        }

        public IEnumerable<Airport> Airports
        {
            get
            {
                return dbContext.Airports
                                .Include(a => a.Location)
                                .Include(a => a.Weather);
            }
        }

        EF.AirportDbContext dbContext = new EF.AirportDbContext();
        
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
