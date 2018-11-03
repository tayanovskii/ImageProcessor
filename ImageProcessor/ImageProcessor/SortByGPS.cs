using System;
using System.IO;
using System.Linq;
using ImageProcessor.Extensions;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Yandex;
using Directory = System.IO.Directory;

namespace ImageProcessor
{
    internal class SortByGps : Processor
    {
        public override void Start()
        {
            var sourcePath = UserInterface.GetSourcePath();
            if (sourcePath == null) return;
            var changedDirName = sourcePath.Replace(sourcePath, sourcePath + "_sort_by_gps");
            var listFiles = Directory.GetFiles(sourcePath, "*.jp*g", SearchOption.AllDirectories);
            foreach (var file in listFiles)
            {
                var gps = ImageMetadataReader.ReadMetadata(file).OfType<GpsDirectory>().FirstOrDefault();
                var location = gps?.GetGeoLocation();
                if (location == null) continue;
                var stringLocations = GetLocation($"{location.Latitude},{location.Longitude}");
                //Console.WriteLine("Image at {0},{1}", location.Latitude, location.Longitude);
                if (stringLocations == null) continue;
                var nameDirByGps = changedDirName + "\\" + stringLocations[0].Trim();
                if (stringLocations.Length > 1) nameDirByGps = nameDirByGps + "\\" + stringLocations[1].Trim();
                if (!Directory.Exists(nameDirByGps)) Directory.CreateDirectory(nameDirByGps);
                var outputFile = nameDirByGps + "\\" + Path.GetFileName(file);
                File.Copy(file, outputFile, true);
            }
        }

        private static string[] GetLocation(string coordinate)
        {
            var results = YandexGeocoder.Geocode(coordinate, 1, LangType.ru_RU);
            foreach (var result in results)
            {
                var text = result.GeocoderMetaData.Text.Trim();
                var locationStrings = text.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                return locationStrings;
            }

            return null;
        }
    }
}