using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Extensions;

namespace ImageProcessor
{


    class Program
    {

        static void Main(string[] args)
        {
           
 
            var flag = true;
            while (flag)
            {
                UserInterface.PrintFunctional();
                var userInput = UserInterface.GetUserInput();
                var userInputToInt = UserInterface.UserInputToInt(userInput);

                switch (userInputToInt)
                {
                    case 1:
                    {
                        Directory:  UserInterface.PrintRequestPath();
                        var path=UserInterface.GetUserInput();
                        var directoryInfo = new DirectoryInfo(path);
                            if (!directoryInfo.Exists)
                        {
                            Console.WriteLine("Некорректный путь");
                            goto Directory;
                        }

                        if (directoryInfo.Parent != null)
                            Directory.CreateDirectory(directoryInfo.FullName.ToUpper() + "_rename_images".ToUpper());

                        var files = Directory.GetFiles(directoryInfo.FullName);
                        foreach (var file in files)
                        {
                            Console.WriteLine(ImageProperty.GetDateFromImage(file).Year);
                            
                        }
                        break;
                    }
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
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
