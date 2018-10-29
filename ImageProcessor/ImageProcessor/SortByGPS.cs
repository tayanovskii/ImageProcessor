using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using ImageProcessor.Extensions;
using Newtonsoft.Json;

namespace ImageProcessor
{
    class SortByGPS:Processor
    {
        public override void Start()
        {
            //var sourcePath = UserInterface.GetSourcePath();
            //if (sourcePath == null) return;

            //var fullParentName = Directory.GetParent(sourcePath).FullName;                                       //разобраться с путями!!!

            //var listFiles = Directory.GetFiles(sourcePath, "*.jp*g", SearchOption.AllDirectories);
            //foreach (var file in listFiles)
            //{
            //    var changedDirName = sourcePath.Replace(sourcePath, sourcePath + "_sort_by_date");
            //    var yearOfFile = ImageProperty.GetDateFromImage(file).Year;
            //    var nameDirByYear = changedDirName + "\\" + yearOfFile;
            //    if (!Directory.Exists(nameDirByYear)) Directory.CreateDirectory(nameDirByYear);
            //    var outputFile = nameDirByYear + "\\" + Path.GetFileName(file);

            //    var image = Image.FromFile(file);
            //    //var propItemLatitude = targetImg.GetPropertyItem(2);
            //    //var propItemLongitude = targetImg.GetPropertyItem(4);
            //    //Console.WriteLine(outputFile + "    " + propItemLongitude + "   " + propItemLatitude);

            //    //File.Copy(file, outputFile, true);
            //}

            //AIzaSyCMKknJ0jyVCYVzRSjbMDGLuYx-qxxRqyw

            //43e2be5e-2161-4ec8-aafd-6c07a01a7fbc

            string coordinate = "32.797821,-96.781720"; //Console.ReadLine();

            var uri =
                $"https://geocode-maps.yandex.ru/1.x/?apikey=43e2be5e-2161-4ec8-aafd-6c07a01a7fbc&format=json&geocode={coordinate}";


            //WebRequest request = WebRequest.Create(uri);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Method = "GET";
            //request.ContentType = "application/json; charset=utf-8";

            //using (var response = request.GetResponse())
            //using (var dataStream = response.GetResponseStream())
            //{
            //    StreamReader reader = new StreamReader(dataStream);
            //    string responseFromServer = reader.ReadToEnd();
            //    Console.WriteLine(responseFromServer);
            //}

            WebClient client = new WebClient();
            var jsonstring = client.DownloadString(uri);
            dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
            string requst = dynObj.request;

            //Console.WriteLine(dynObj);



            // XmlDocument xDoc = new XmlDocument();
            //// https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY
            // xDoc.Load($"https://maps.googleapis.com/maps/api/geocode/xml?latlng={coordinate}&key=sadfwet56346tyeryhretu6434tertertreyeryeryE1");

            // XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
            // XmlNode xNode = xNodelst.Item(0);
            // string FullAddress = xNode.SelectSingleNode("formatted_address").InnerText;
            // string Number = xNode.SelectSingleNode("address_component[1]/long_name").InnerText;
            // string Street = xNode.SelectSingleNode("address_component[2]/long_name").InnerText;
            // string Village = xNode.SelectSingleNode("address_component[3]/long_name").InnerText;
            // string Area = xNode.SelectSingleNode("address_component[4]/long_name").InnerText;
            // string County = xNode.SelectSingleNode("address_component[5]/long_name").InnerText;
            // string State = xNode.SelectSingleNode("address_component[6]/long_name").InnerText;
            // string Zip = xNode.SelectSingleNode("address_component[8]/long_name").InnerText;
            // string Country = xNode.SelectSingleNode("address_component[7]/long_name").InnerText;
            // Console.WriteLine("Full Address: " + FullAddress);
            // Console.WriteLine("Number: " + Number);
            // Console.WriteLine("Street: " + Street);
            // Console.WriteLine("Village: " + Village);
            // Console.WriteLine("Area: " + Area);
            // Console.WriteLine("County: " + County);
            // Console.WriteLine("State: " + State);
            // Console.WriteLine("Zip: " + Zip);
            // Console.WriteLine("Country: " + Country);

            //return locationName;

            //var uri = $"http://maps.google.com/maps/api/geocode/json?address={HttpUtility.UrlEncode(address)}&sensor=false";

            //var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            //var response = (HttpWebResponse)request.GetResponse();


        }
    }
}
