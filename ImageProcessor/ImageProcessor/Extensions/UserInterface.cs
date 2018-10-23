using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Extensions
{
    public class UserInterface
    {
        public static void PrintFunctional()
        {
            Console.WriteLine("Введите номер необходимой команды (1,2,3,4 или 5):");
            Console.WriteLine("1.Переименовать изображения в соответствии с датой сьемки");
            Console.WriteLine("2.Добавить на изображение отметку, когда фото было сделано");
            Console.WriteLine("3.Сортировка изображений по папкам по годам");
            Console.WriteLine("4.Сортировка изображений по папкам по месту сьемки");
            Console.WriteLine("5.Выход!!!");

        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static short UserInputToInt(string userInput)
        {
            return short.TryParse(userInput, out var userInputToInt) ? userInputToInt : (short) 0;
        }

        public static void PrintRequestPath()
        {
            Console.WriteLine("Введите путь к папке изображений (с:\\images\\):");
        }

        
    }
}
