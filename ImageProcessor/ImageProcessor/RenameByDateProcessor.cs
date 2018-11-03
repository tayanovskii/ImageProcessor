using System.IO;
using ImageProcessor.Extensions;

namespace ImageProcessor
{
    internal class RenameByDateProcessor : Processor
    {
        public override void Start()
        {
            var sourcePath = UserInterface.GetSourcePath();
            if (sourcePath == null) return;
            var listFiles = Directory.GetFiles(sourcePath, "*.jp*g", SearchOption.AllDirectories);
            foreach (var file in listFiles)
            {
                var changedDirName = Path.GetDirectoryName(file).Replace(sourcePath, sourcePath + "_rename_images");
                if (!Directory.Exists(changedDirName)) Directory.CreateDirectory(changedDirName);
                var outputFile = changedDirName + "\\" + Path.GetFileNameWithoutExtension(file) + "_" +
                                 ImageProperty.GetDateFromImage(file).ToString("yyyy-MM-dd") + Path.GetExtension(file);
                File.Copy(file, outputFile, true);
            }
        }
    }
}