using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Data.EF
{
    class AirportDbContext : DbContext//унаследовали из библ.класса
    {
        //todo where is datasset created
        public DbSet<Airport> Airports { get; set; }

        // https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//to do read info about OnConfiguring
            // TODO: move the connection string to the configuration file
            const string dbName = "AirportsDb";//что это за константа
            optionsBuilder.UseSqlServer(
                $@"Server=(localdb)\mssqllocaldb;Database={dbName};Trusted_Connection=True;");//расшифровка строк подключения на будущее Trusted_Connection=True;
            optionsBuilder.EnableSensitiveDataLogging();//switch on migration for debugging
            base.OnConfiguring(optionsBuilder);//methode invocation from parental c
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeding Airports table
            // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            // 1.я создаю нужные аэропорты и кладу их в список `seededAirports`
            var seededAirports = new[]
            {
                CreateSeedAirportWithLocation("Florence","Amerigo Vespuchi", -1, -1),
                CreateSeedAirportWithLocation("Elabuga", "Kazan",-2, -2),
                CreateSeedAirportWithLocation("Gatwick", "Gatwick",-3, -3),
                CreateSeedAirportWithLocation("Innsbruk","Kranebitten", -4, -4),
                CreateSeedAirportWithLocation("Budapest", "Ferenc Liszt",-5, -5),
                CreateSeedAirportWithLocation("Bucharest","Henri Coandă", -6, -6),
                CreateSeedAirportWithLocation("Buchara", "Buchara",-7, -7)
            };

            // к объекту modelBuilder создаем базу и вызываем метод HasData
            // todo WHAT IS GENERIC
            //2. сидирование location'ов 
            modelBuilder.Entity<Location>().HasData(seededAirports.Select(a => a.Location));
            // workaround for bug https://github.com/aspnet/EntityFrameworkCore/issues/10000
            //он о том, что миграции в EF 2.1 (это наша версия) 
            //всё ещё не умеют работать с навигационными свойствами, 
            //и что нужно их убрать, и установить самим внешние ключи

            foreach (var a in seededAirports)
                a.Location = null;
            modelBuilder.Entity<Airport>().HasData(seededAirports);

            base.OnModelCreating(modelBuilder);
        }

        Airport CreateSeedAirportWithLocation(string locationName, string airportName, int airportId, int locationId)
        {
            return new Airport()
            {//добавление foreign key внутри функции 
                Id = airportId,// Airport has its own primary key
                LocationId = locationId,//Location id is a foreign key for Airport

                Name = airportName,

                Location = new Location()
                {
                    Id = locationId,//primary key for Location
                    Name = locationName
                }
            };
        }
    }
}
