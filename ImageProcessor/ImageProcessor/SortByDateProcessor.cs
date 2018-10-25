using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    class SortByDateProcessor : Processor
    {
        public override void Start()
        {
            var sourcePath = UserInterface.GetSourcePath();
            if (sourcePath == null) return;
            //var fullParentName = Directory.GetParent(sourcePath).FullName;                    разобраться с путями!!!
            var listFiles = Directory.GetFiles(sourcePath, "*.jp*g", SearchOption.AllDirectories);
            foreach (var file in listFiles)
            {
                var changedDirName = sourcePath.Replace(sourcePath, sourcePath + "_sort_by_date");
                var yearOfFile = ImageProperty.GetDateFromImage(file).Year;
                var nameDirByYear = changedDirName + "\\" + yearOfFile;
                if (!Directory.Exists(nameDirByYear)) Directory.CreateDirectory(nameDirByYear);
                var outputFile = nameDirByYear + "\\" + Path.GetFileName(file);
                File.Copy(file, outputFile, true);
            }
        }
    }
}
