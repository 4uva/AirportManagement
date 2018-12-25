using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.Data
{
   public class Airport
    {//название аэропорта прибытия, город аэропорта
     //прибытия, погода в аэропорту прибытия, часовой
     // пояс аэропорта прибытия — все эти данные 
     //можно считать частью прибытия
    
     public Location Location{ get; set; }
     public Weather Weather{ get; set; }
    public TimeZoneInfo LocalTimeZone{ get; set; }
        
        

    }
}
