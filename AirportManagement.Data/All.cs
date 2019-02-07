﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Data
{
    //добавить списки, аэропортов, полётов, и авиакомпаний
    public class All : DbContext//унаследовали из библ.класса
    {//todo where is datasset created
        public DbSet<Airport> Airports { get; set; }//List updated to Dataset

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//to do read info about OnConfiguring
            // TODO: move the connection string to the configuration file
            const string dbName = "AirportsDb";//что это за константа
            optionsBuilder.UseSqlServer(
                $@"Server=(localdb)\mssqllocaldb;Database={dbName};Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeding Airports table
            // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            
            var seededAirports = new[]
            {
                CreateSeedAirportWithLocation("Florence", -1, -1),
                CreateSeedAirportWithLocation("Elabuga", -2, -2),
                CreateSeedAirportWithLocation("Gatwick", -3, -3),
                CreateSeedAirportWithLocation("Innsbruk", -4, -4),
                CreateSeedAirportWithLocation("Budapest", -5, -5),
                CreateSeedAirportWithLocation("Bucharest", -6, -6),
                CreateSeedAirportWithLocation("Buchara", -7, -7)
            };

            // к объекту modelBuilder создаем базу и вызываем метод HasData 
            modelBuilder.Entity<Location>().HasData(seededAirports.Select(a => a.Location));
            // workaround for bug https://github.com/aspnet/EntityFrameworkCore/issues/10000
            foreach (var a in seededAirports)
                a.Location = null;
            modelBuilder.Entity<Airport>().HasData(seededAirports);

            base.OnModelCreating(modelBuilder);
        }
        
        Airport CreateSeedAirportWithLocation(string locationName, int airportId, int locationId)
        {
            return new Airport()
            {
                Id = airportId,// Airport has its own primary key
                LocationId = locationId,//Location id is a foreign key for Airport
                Location = new Location()
                {
                    Id = locationId,//primary key for Location
                    Name = locationName
                }
            };
        }
        // utility functions

        public Airport AddAirport(string locationName)
        // создали публичную функцию добавить аэропорт , котррая
        //возращает аэропорт и на вход получает имя аэропорта
        {
            var a = CreateAirport(locationName);
            //создали переменную и присвоили ей значение вызова 
            //функции с параметром локация аэропорта
            Airports.Add(a);//добавили экземпляр аэропорта 
            //со значением фактического параметра а
            return a;
            //вернули значение фактического параметра
        }

        public void DeleteAirport(Airport airport)
        {   
            Airports.Remove(airport);
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

        //поле r
        //All All2 { get; set; }  свойство
        public void Create()
        {
            AddAirport("Florence");//вызвали экземпляр списка
            AddAirport("Elabuga");
            AddAirport("Gatwick");
            AddAirport("Innsbruk");
            AddAirport("Budapest");
            AddAirport("Bucharest");
            AddAirport("Buchara");
        }

        public List<Airport> GetFilteredByPartialLocationAirports(string partialLocation)
        {
            return Airports
                .Where(a => a.Location.Name.Contains(partialLocation, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(a => a.Location.Name)
                .ToList();
        }
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
