using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagement.Data
{
    public class Location
    {
        public string Name { get; set; }

        [NotMapped]
        public TimeZoneInfo LocalTimeZone
        {
            get { return TimeZoneInfo.FindSystemTimeZoneById(LocalTimeZoneName); }
            set { LocalTimeZoneName = value.Id; }
        }

        public string LocalTimeZoneName { get; set; }

        public int Id { get; set; }
    }
}