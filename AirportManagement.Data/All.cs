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
        public Airport AddAirport(string airportName, string locationName)
        // создали публичную функцию добавить аэропорт , котррая
        //возращает аэропорт и на вход получает имя аэропорта
        {
            var a = CreateAirport(airportName, locationName);
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

        Airport CreateAirport(string airportName, string locationName)
        {
            return new Airport()
            {
                Name = airportName,
                Location = new Location
                {
                    Name = locationName
                }
            };
        }

        public List<Airport> GetFilteredAirports(string partialName)
        {//todo WHAT IS LINQ
            return Airports
                .Where(a => a.Location.Name.Contains(partialName, StringComparison.InvariantCultureIgnoreCase) ||
                            a.Name.Contains(partialName, StringComparison.InvariantCultureIgnoreCase))
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
