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
            var listFiles = Directory.GetFiles(sourcePath,"*.jp*g",SearchOption.AllDirectories);
            foreach (var file in listFiles)
            {
                var changedDirName = Path.GetDirectoryName(file).Replace(sourcePath, sourcePath + "_rename_images");
                if(!Directory.Exists(changedDirName)) Directory.CreateDirectory(changedDirName);
                var outputFile = changedDirName + "\\" + Path.GetFileNameWithoutExtension(file) + "_" + ImageProperty.GetDateFromImage(file).ToString("yyyy-MM-dd") + Path.GetExtension(file);
                File.Copy(file, outputFile, true);
            }
        Exit:;

        }
    }
}
