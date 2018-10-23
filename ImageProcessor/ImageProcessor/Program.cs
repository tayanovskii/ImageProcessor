using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.PrintFunctional();
            var userInput = UserInterface.ReadUserInput();
            var userInputToInt = UserInterface.UserInputToInt(userInput);
            Console.WriteLine(userInputToInt);
            UserInterface.PrintRequestPath();
            Console.ReadKey();
        }
    }
}
