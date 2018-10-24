using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    class AddDateProcessor: Processor
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
            var listFiles = Directory.GetFiles(sourcePath, "*.jp*g", SearchOption.AllDirectories);
            foreach (var file in listFiles)
            {
                var changedDirName = Path.GetDirectoryName(file).Replace(sourcePath, sourcePath + "_write date on photo");
                if (!Directory.Exists(changedDirName)) Directory.CreateDirectory(changedDirName);
                var outputFile = changedDirName + "\\" + Path.GetFileName(file);
                var dateFromImage = ImageProperty.GetDateFromImage(file).ToString("MM-dd-yyyy HH:mm");
                var image = Image.FromFile(file);
                using (var graphics = Graphics.FromImage(image))
                {
                    using (var arialFont = new Font("Arial", 80))
                    {
                        graphics.DrawString(dateFromImage, arialFont, Brushes.White, new System.Drawing.Point(image.Width - 800, image.Height - 200));
                    }
                }
                image.Save(outputFile);

            }
        Exit:;
        }
    }
}
