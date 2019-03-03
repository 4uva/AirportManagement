using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    public class AirportViewModel : ViewModel
    {
        public AirportViewModel(Airport airport)
        {
            //когда функция обращается к полю, то она при этом фактически
            //работает с полем какого - то конкретного объекта
            //ну вот этот самый объект и имеет имя `this` внутри функции
            this.airport = airport;//AirportViewModel тип this
            name = airport.Name;
            locationName = airport.Location.Name;
        }

        string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);//присваивание свойству есть вызов сеттера
        }

        string locationName;
        public string LocationName
        {
            get => locationName;// => == return locationName
            set => Set(ref locationName, value);
            //set { Set(ref locationName, value); }`
        }

        Airport airport;//зачем нам эта строка
    }
}