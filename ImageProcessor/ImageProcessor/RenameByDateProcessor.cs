using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    class RenameByDateProcessor: Processor
    {
        public override void Start()
        {

            Console.WriteLine("Введите путь к папке изображений (с:\\temp\\images):");
            var sourcePath = Console.ReadLine();
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Некорректный путь!");
                goto Exit;
            }
            var directoryInfo = new DirectoryInfo(sourcePath);
            //var fullParentName = Directory.GetParent(sourcePath).FullName;                    разобраться с путями!!!
            var destinationPath = directoryInfo.FullName + "_rename_images".ToUpper();
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            var files = Directory.GetFiles(sourcePath);
            foreach (var file in files)
            {
                //Console.WriteLine(ImageProperty.GetDateFromImage(file).Year);
                var extensionOfFile = System.IO.Path.GetExtension(file);
                if (extensionOfFile.Contains(".jpg") || extensionOfFile.Contains(".jpeg"))
                {
                    var outputFile = destinationPath + "\\" +
                                     System.IO.Path.GetFileNameWithoutExtension(file) + "_" +
                                     ImageProperty.GetDateFromImage(file).ToString("yyyy-MM-dd") +
                                     extensionOfFile;
                    File.Copy(file, outputFile);
                }

            }

            Exit:;

        }
    }
}
