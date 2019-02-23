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
            Console.SetWindowSize(60, 25);
            Console.SetBufferSize(60, 1000);

            while (true)
            {
                using (var repository = new Repository())
                {
                    MainLogic logic = new MainLogic(repository);
                    StepResult result = logic.RunStep();
                    //вызываем у бизнес логики функцию 
                    //так мы раньше вызывали меню 
                    //и значение и присваиваем в переменную
                    if (result == StepResult.Exit)//это переписанный Userchoicecancel
                        break;
                }
            }
        }
    }
}
