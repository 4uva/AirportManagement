using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportManagement.WPF
{
   // интерфейс ICommand представляет собой команду
   //точнее, любой класс, который его реализуе
    class RelayCommand : ICommand
    {
        protected readonly Func<bool> canExecute;//поле делегатного типа
        protected readonly Action execute;//это поле типа Action

        public event EventHandler CanExecuteChanged;
        //`event` /* <- объявляется событие */ `EventHandler` /
        //    * <- делегат с сигнатурой методов, которые можно 
        //    подписывать на это событие */ `CanExecuteChanged` 
        //    /* <- имя события */ (edited)
        // 
        //EventHandler(object sender, EventArgs args)` для событий, 
        //EventHandler рекомендуется сигнатура `void
        //которые не передают никаких данных  рекомендуется сигнатура 
        //void EventHandler(object sender, EventArgs args)` для событий, 
        // Represents the method that will handle an event that has no event
        //data sender -обычно в этот аргумент запихивает(ссылку на) себя тот, 
        //кто отправляет событие


       
        // тут аргументы функции типа Action  execute,но еxecute просто переменная типа Action
        // тут аргументы функции типа Func<bool>  , но  canExecuteпросто переменная типа Func<bool>
        public RelayCommand(Action execute, Func<bool> canExecute)//конструктор
        {
            // метод можно запихнуть в переменную, а делегат — тип этой переменной строка 36
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            this.execute = execute;
            //(nameof(execute)) поэтому это как бы дополнительная подстраховка, что ты реально 
            //написала имя параметра
            //берем значение поля, поэтому this и инициализируем его, если значение параметра null, 
            //то бросаем исключение. Что дает исключение я не знаю
            this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }// конструктор и проверка на 0

        public  RelayCommand(Action execute) : this(execute, () => true)//«делегирующий конструктор»
        {

//            мы определяем конструктор `public RelayCommand`
//            с одним параметром `(Action execute)`, который 
//            для начала вызывает другой конструктор с двумя 
//            параметрами `: this(` и передаёт ему в качестве 
//            первого параметра полученное на вход значение 
//            `execute,` , а в качестве второго лямбда-фукнцию, 
//            которая возвращает всегда true `() => true` 
//            параметры закончились `)` и больше ничего не делает `{ }`
//`          () => true`: пара скобок означает пустой список параметров лямбды
        }
     
        public bool CanExecute(object parameter) => canExecute();// return вызов функции правильно?
        //функцию там передали, мы её сохранили
        //в поле, и вызвали, когда нужно
        //вызов функции, которая лежит в делегате
        public void Execute(object parameter) => execute();
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);//ну это статическое поле
           // поэтому обращение через точку к типу, а не к экземпляр
            //if (CanExecuteChanged != null)
            //    CanExecuteChanged.Invoke(this, EventArgs.Empty);
            //вызов функции Invoke у другой функции CanExecuteChanged?с проверкой на null

            //(в аргументах у нас значение поля this, EventArgs.Empty- а эту конструкцию не могу сказать);
        }
    }
}
