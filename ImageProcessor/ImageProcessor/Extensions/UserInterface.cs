using System;
using System.Collections.Generic;
using System.IO;
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
        public static short InputStringToInt(string userInput)
        {
            return short.TryParse(userInput, out var userInputToInt) ? userInputToInt : (short) 0;
        }

        public static string GetSourcePath()
        {
            Console.WriteLine("Введите путь к папке изображений (с:\\temp\\images):");
            var sourcePath = Console.ReadLine();
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Некорректный путь!");
                sourcePath = null;
            }

            return sourcePath;
        }
    }
}
