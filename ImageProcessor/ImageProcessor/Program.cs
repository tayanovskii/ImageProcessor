using System;
using System.IO;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var flag = true;
            while (flag)
            {
                UserInterface.PrintFunctional();
                var userInput = Console.ReadLine();
                var userInputToInt = UserInterface.InputStringToInt(userInput);
               
                switch (userInputToInt)
                {
                    case 1:
                    {
                      FabricProcessors.Get(1).Start();
                        break;
                    }
                    case 2:
                    {
                        FabricProcessors.Get(2).Start();
                        break;
                    }
                    case 3:
                    {
                        FabricProcessors.Get(3).Start();
                        break;
                    }
                    case 4: break;
                    case 5:
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Некорректный ввод");
                        break;
                    }
                }
            }

            //Console.ReadKey();
        }
    }
}