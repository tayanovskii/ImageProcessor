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
            var destinationPath = directoryInfo.FullName + "_add_Date_images".ToUpper();
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            var files = Directory.GetFiles(sourcePath);
            foreach (var file in files)
            {
                var extensionOfFile = System.IO.Path.GetExtension(file);
                if (extensionOfFile.Contains(".jpg") || extensionOfFile.Contains(".jpeg"))
                {
                    var dateFromImage = ImageProperty.GetDateFromImage(file).ToString("MM-dd-yyyy HH:mm");
                    var nameOfFile = new FileInfo(file).Name;
                    var image = Image.FromFile(file);
                    using(var graphics = Graphics.FromImage(image))
                    {
                        using (var arialFont = new Font("Arial", 80))
                        {
                            graphics.DrawString(dateFromImage, arialFont, Brushes.White, new System.Drawing.Point(image.Width - 800, image.Height - 200));
                        }
                    }
                    image.Save(destinationPath+"\\"+nameOfFile);
                }
            }

            Exit:;
        }
    }
}
