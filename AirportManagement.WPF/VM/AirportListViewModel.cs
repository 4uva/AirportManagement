using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirportManagement.Data;

namespace AirportManagement.WPF.VM
{
    class AirportListViewModel : ViewModel// почему class AirportListViewModel наследуется от ViewModel// класс отвечающий за бизнес-логику в WPF 
                                          //и что это значит 
    {
        //имя совпадает с именем класса + нет возвращаемого типа - функция AirportListViewModel - к*/онструктор
        public AirportListViewModel(Repository repository)//читаем данные из базы
        {
            this.repository = repository;//это инициализация поля, так как поле лежит в this

            foreach (var airport in repository.Airports)//это же обращение к объекту другого класса
            {
                AirportViewModel airportViewModel = new AirportViewModel(airport); //создаем аэропорт для слоя WM
                Airports.Add(airportViewModel);//добавляем аэропорт AirportViewModel
                FilteredAirports.Add(airportViewModel);// добавляем viewmodel airport   
                //FilteredAirports -это  свойство из строки   public ObservableCollection<AirportViewModel> FilteredAirports
                filteredAirportsSet.Add(airportViewModel);//добавлен список аэропортов
                //filteredAirportsSet,где оно инициализировано
            }
           
            DeleteSelectedAirportCommand =
                new RelayCommand(OnDeleteSelectedAirport, CanDeleteSelectedAirport);
        }//тип Action представляет собой (ссылку на) функцию
         //поэтому когда мы передаём в конструктор функцию, всё в порядке

        //мы передаём в команду функции экземпляр  RelayCommand хочет на вход функции


        // новенькое: инициализация в строке 40
        //мы инициализируем свойство один раз в начале новой 
        //// ObservableCollection<AirportViewModel>
        //и поскольку свойства у нас не имею сеттера, то снаружи их установить низзя
        //так что у класса AirportViewModel жОсткий контроль над своим свойством

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
                                                                                 //подходит ли он под нов   FilteredAirports.Remove(airport);
                filteredAirportsSet.Remove(airport);
                bool mustBeInFilteredListNow = CheckFilter(airport, filter);////а это список Бухарест, Бухара
                if (isInOldFilteredList && !mustBeInFilteredListNow)//сначала мы проверяем ситуацию, что есть в старом, а в новом не нужно 
                                                                    //если в старом списке есть, но в новом не нужно
                {
                    FilteredAirports.Remove(airport);//РАЗОБРАТЬ ФУНКЦИЮ ПОТОМ
                    filteredAirportsSet.Remove(airport);
                }
                // else if (!isInOldFilteredList && mustBeInFilteredListNow)
                else
                {
                    if (!isInOldFilteredList && mustBeInFilteredListNow) //если нет в старом но нужен в новом
                    {
                        FilteredAirports.Add(airport);
                        filteredAirportsSet.Add(airport);
                    }
                }
            }
        }
        //CheckFilter решает, подходит список под фильтр или нет
        bool CheckFilter(AirportViewModel airport, string filter)// string filter- я не пойму этот параметр
        {//nullотличается от  ""чем отсутствие вагона отличается 
            //от пустого вагона? и там, и там нету пассажиров
            if (filter == null || filter == "")// фильтрация по пустому фильтру даёт весь список
                return true;

            // тут у нас есть непустой фильтр
            return airport.Name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1 ||//обращение к enum-константе так и только так: имя типа, точка, имя константы
                airport.LocationName.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) != -1;
        }
        AirportViewModel selectedAirport;
        public AirportViewModel SelectedAirport
        {
            get => selectedAirport;
            set
            {
                if (Set(ref selectedAirport, value))
                    DeleteSelectedAirportCommand.RaiseCanExecuteChanged();//вызов функции у объекта того же типа, 
               // что и класс функции

            }
        }

        public RelayCommand DeleteSelectedAirportCommand { get; }
        
        //в строке 109 свойство, содержащее команду
        //команда — это объект, реализующий интерфейс ICommand
        //у неё можно вызвать функцию Execute &CanExecute
        void OnDeleteSelectedAirport()
        {
            repository.DeleteAirport(SelectedAirport.airport);// selectedairport contains reference for entity
            FilteredAirports.Remove(SelectedAirport);
            filteredAirportsSet.Remove(SelectedAirport);
              Airports.Remove(SelectedAirport);
            SelectedAirport = null;
            // удаляем аэропорт через репозиторий
            // но у нас его нету :( кого нет? репозитория нету в этом классе или есть? есть 
            // ага, мы его просто не сохранили в поле
            // поэтому и не могли к нему обратиться после конструктора
            // заводим поле
        }

        bool CanDeleteSelectedAirport() => SelectedAirport != null;
       
        // [v] 1. кладём свойство SelectedAirport
        // [v] 2. кладём команду DeleteSelectedAirportCommand
        // [v] 3. команда будет удалёть из базы выбранный (selected) аэропорт
        // [v] 4. когда SelectdAirport == null, команду нужно отключать

        public ObservableCollection<AirportViewModel> Airports { get; } =//строки 26-29 даже по типу не могу понять что это
            new ObservableCollection<AirportViewModel>();

        //FilteredAirports — это свойство
        //про инициализацию:
        //в новой версии C# можно инициализировать не только в конструкторе, 
        //а и прямо после объявления свойства через знак `=` 

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

        // for fast searching
        HashSet<AirportViewModel> filteredAirportsSet = new HashSet<AirportViewModel>();//похоже на конструктор списка, но другой тип

        //чем оно хорошо: в нём поиск быстрый, намного быстрее, 
        //чем в списках типа ObservableCollection<T> или List<T>(edited)
        //недостаток: в нём элементы неупорядочены
        //таким образом, филтрованные аэропорты у нас в двух местах
        //в FilteredAirports для View
        //и в filteredAirportsSet — для себя, чтобы быстро искать, 
        //у нас аэропорт есть в фильтре или нет

        Repository repository ;

        //1) никакого другого места, где лежит нужная информация, нет
        //2) взять из 1), мы об этом очень долго ругались

        //1) даёт тебе VM-аэропорт
        //2) позволяет из этого VM-аэропорта получить модельный аэропорт
        //который и требуется для репозитория

    }
}
//getter не записывает, он читает
//но геттер у нас не автоматический, 
//    откуда он берёт значение?
//из поля selectedAirport
//таким образом, setter будет писать 
//в секретное поле, 
// а getter выдавать значение из 
//    поля selectedAirport, в которое
//    мы никогда ничего не записывали(edited)
//не пользкемся  автоматическим сеттером?
//раз он не делает того, что нам надокроме того,
//мы в сеттере должны отправлять сообщение
//    NorifyPropertyChanged//