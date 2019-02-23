using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    class AirportListViewModel : ViewModel// почему class AirportListViewModel наследуется от ViewModel
        //и что это значит 
    {
       //имя совпадает с именем класса + нет возвращаемого типа - функция AirportListViewModel - к*/онструктор
        public AirportListViewModel(All all)//читаем данные из базы
        {
            foreach (var airport in all.Airports)//это же обращение к объекту другого класса
            {
                AirportViewModel airportViewModel = new AirportViewModel(airport);
                Airports.Add(airportViewModel);
                FilteredAirports.Add(airportViewModel);//FilteredAirports -это  свойство из строки   public ObservableCollection<AirportViewModel> FilteredAirports
                filteredAirportsSet.Add(airportViewModel);//filteredAirportsSet,где оно инициализировано
            }
        }

        public ObservableCollection<AirportViewModel> Airports { get; } =//строки 26-29 даже по типу не могу понять что это
            new ObservableCollection<AirportViewModel>();


//        FilteredAirports — это свойство, в строке 38
//про инициализацию:
//смотрив новой версии C# можно инициализировать не только в конструкторе, 
//а и прямо после объявления свойства через знак `=` (edited) 
//мы это делаем в строке 27 и 29
//с большой буквы потому, что публичное


        public ObservableCollection<AirportViewModel> FilteredAirports { get; } =
          //`ObservableCollection<T>` — это ещё один тип списка
        //она как `List<T>`, но с отличием
        //отличие в том, что она реализует интерфейс `INotifyCollectionChanged
        //`INotifyCollectionChanged(не `INotifyPropertyChanged`!)
           
        //смысл этого интерфейса в том, что коллекция отправляет событие(event) 
        //при каждом добавлении и удалении элемента (edited)
        //при этом View умеет этими событиями пользоваться
        //и когда мы добавим или удалим элемент коллекции, 
        // View тоже обновится, и добавит/удалит элемент списка на экране  
            new ObservableCollection<AirportViewModel>();

        // новенькое: инициализация в строке 40
        //мы инициализируем свойство один раз в начале новой 
        //// ObservableCollection<AirportViewModel>
        //и поскольку свойства у нас не имею сеттера, то снаружи их установить низзя
        //так что у класса AirportViewModel жОсткий контроль над своим свойством

        // for fast searching
        HashSet<AirportViewModel> filteredAirportsSet = new HashSet<AirportViewModel>();//похоже на конструктор списка, но другой тип

        //чем оно хорошо: в нём поиск быстрый, намного быстрее, 
        //чем в списках типа ObservableCollection<T> или List<T>(edited)
        //недостаток: в нём элементы неупорядочены
        //таким образом, филтрованные аэропорты у нас в двух местах
        //в FilteredAirports для View
        //и в filteredAirportsSet — для себя, чтобы быстро искать, 
        //у нас аэропорт есть в фильтре или нет

        string filter;//эну как и раньше: это поле, в котором будет содержаться значение свойства
        public string Filter//это свойство
        {//тут хаос начинается
            get => filter;//
            set
            {
                //вызывается функция Set и если она возвращает
                //true(а это происходит, если,
                //значение реально изменилось), то вызывается
                //функция ApplyFilter
                if (Set(ref filter, value))
                    ApplyFilter(value);
            }
        }//тут хаос завершается

        void ApplyFilter(string filter)//метод употребление фильтра
        {
            // add airports which are not in the list
            foreach (var airport in Airports)
            {//есть ли он в старом фильтрованном списке?
                bool isInOldFilteredList = filteredAirportsSet.Contains(airport);//это первый ввод - например Бухар
                //подходит ли он под новый фильтр? если да, то он должен быть в новом фильтрованном списке
                bool mustBeInFilteredListNow = CheckFilter(airport, filter);////а это список Бухарест, Бухара
                if (isInOldFilteredList && !mustBeInFilteredListNow)//не пойму что true а что false до конца метода
                {
                    FilteredAirports.Remove(airport);
                    filteredAirportsSet.Remove(airport);
                }
                else if (!isInOldFilteredList && mustBeInFilteredListNow)
                {
                    FilteredAirports.Add(airport);
                    filteredAirportsSet.Add(airport);
                }
            }
        }

        bool CheckFilter(AirportViewModel airport, string filter)
        {//nullотличается от  ""чем отсутствие вагона отличается 
            //от пустого вагона? и там, и там нету пассажиров
            if (filter == null || filter == "")
                return true;

            // тут у нас есть непустой фильтр
            return airport.Name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1 ||
                airport.LocationName.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1;
        }
    }
}
