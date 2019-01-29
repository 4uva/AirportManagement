using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportManagement.Data;
using AirportManagement.Data.Storage;
using AirportManagement.Presentation;
using AirportManagement.BusinessLogic;
namespace AirportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, -1, 5, 8, 2 };

            foreach (int number in numbers)
            { 
                if (number > 3)
                Console.WriteLine (number);
            }

            

            // Constructor invocation for this object is not relevant anymore
            All all = WriterReader.Read();//создаем экземпляр класса

            MainLogic logic = new MainLogic(all);
            //заводим экземпляр бизнес логики вместо экземпляра меню
            while (true)
            {
                StepResult result = logic.RunStep();
                //вызываем у бизнес логики функцию 
                //так мы раньше вызывали меню 
                //и значение и присваиваем в переменную
                if (result == StepResult.Exit)//это переписанный Userchoicecancel
                    break;
            }
            WriterReader.Write(all);//статический метод вызывается у класса
            Console.ReadKey();
        }
    }
}
