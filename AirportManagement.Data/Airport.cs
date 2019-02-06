namespace AirportManagement.Data
{
    public class Airport //чтобы тут не было, поля, 
                         //переменные свойства -это определение класса
    {
        //название аэропорта прибытия, город аэропорта
        //прибытия, погода в аэропорту прибытия, часовой
        // пояс аэропорта прибытия — все эти данные 
        //можно считать частью прибытия

        //TODO: добавить конструктор, устанавливающий Location
        public Location Location { get; set; }
        public Weather Weather { get; set; }

        public int Id { get; set; }
    }
}
