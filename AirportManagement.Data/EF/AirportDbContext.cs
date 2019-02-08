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
            // todo WHAT IS GENERIC
            modelBuilder.Entity<Location>().HasData(seededAirports.Select(a => a.Location));
            //из каждого аэропорта берём `Location`, и делаем из них 
            //новый список~ новую коллекцию
            //и то, что получилось, передаём аргументом
            //в HasDataто есть все локации
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
    }
}
