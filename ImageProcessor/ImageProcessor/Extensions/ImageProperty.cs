using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageProcessor.Extensions
{
    class ImageProperty
    {
        private static readonly Regex DataRegex = new Regex(":");
        public static DateTime GetDateFromImage(string path)
        {
            var dateTaken = File.GetCreationTime(path).ToString();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var myImage = Image.FromStream(fs, false, false))
            {
                try
                {
                    var propItem = myImage.GetPropertyItem(36867);
                    dateTaken = DataRegex.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);

                }
                catch
                {
                    // ignored
                }
                return DateTime.Parse(dateTaken);

            }
        }

    }
}
