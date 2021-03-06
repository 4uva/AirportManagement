﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Data
{
    //добавить списки, аэропортов, полётов, и авиакомпаний
    public class Repository : IDisposable
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

        Airport CreateAirport(string airportName, string locationName) => new Airport()
            {
                Name = airportName,
                Location = new Location
                {
                    Name = locationName
                }
            };

        public List<Airport> GetFilteredAirports(string partialName) =>
        //todo WHAT IS LINQ
            // TODO: use overload of Contains with StringComparison.InvariantCultureIgnoreCase when available
            Airports
                .Where(a => a.Location.Name.IndexOf(partialName, StringComparison.InvariantCultureIgnoreCase) != -1 ||
                            a.Name.IndexOf(partialName, StringComparison.InvariantCultureIgnoreCase) != -1)
                .OrderBy(a => a.Location.Name)
                .ToList();

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
