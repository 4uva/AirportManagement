using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.WPF.VM
{
    // базовый класс для всех view model-классов
    public class ViewModel : INotifyPropertyChanged//реализует интерфейс
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        // у нас функция (вызвать могут только наследники) которая возвращает true/false, а принимает
        // с аргументами я не понимаю чего-то 
        {
            if (EqualityComparer<T>.Default.Equals(field, value))//одинаковы до вызова
                return false;
            field = value;//стали одинаковыми в результате вызова
            RaisePropertyChanged(propertyName);//вызывается метод чтоб изменить поле
            return true;
        }

        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //=> -это return  `?.` — это проверка на null- PropertyChanged?  и вызов метода 
        //PropertyChanged` равно `null`, если никто не подписался
        //Invoke(this, new PropertyChangedEventArgs(propertyName)); с аргумепнтами 
        // this - это ж текущий объект
        //new PropertyChangedEventArgs(propertyName)) - это просто тип, который содержит имя свойства, которое изменилось
    }
}
