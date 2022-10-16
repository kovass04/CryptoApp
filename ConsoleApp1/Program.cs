using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;

namespace CryptoApp
{
    public class WeatherForecast
    {
    
        public string Name { get; set; }

        public double Change_24h { get; set; }

        public double Volume_24h { get; set; }

        public string Asset_id { get; set; }



    }

    public class MyArray
    {
        public List<WeatherForecast>? Assets { get; set; }
     
    }






    //
    public class Part : IEquatable<Part>, IComparable<Part>
    {
        public string PartName { get; set; }

        public double PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }

        public int CompareTo(Part comparePart)
        {
            if (comparePart == null)
                return 1;

            else
                return this.PartId.CompareTo(comparePart.PartId);
        }
      
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
    }
        //



        public class Program
    {
        public static void Main()
        {
            string fileName = @"C:\Users\kovas\source\repos\CryptoApp\ConsoleApp1\assets.json";
            string jsonString = File.ReadAllText(fileName);
/*          WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;

            Console.WriteLine($"Date: {weatherForecast.asset_id}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.name}");*/

            var temp = (MyArray)JsonConvert.DeserializeObject(jsonString, typeof(MyArray));

            List<Part> forecast = new List<Part>();

            foreach (WeatherForecast item in temp.Assets)
            {
                //Console.WriteLine("volume: {0}, Value {1} ", item.Volume_24h, item.Name);
                // item.Volume_24h;
                forecast.Add(new Part() { PartName = item.Name, PartId = item.Volume_24h });

            }



            foreach (Part aPart in forecast)
            {
                Console.WriteLine(aPart);
            }

            forecast.Sort();
            forecast.Reverse();


            Console.WriteLine("\nAfter sort by part number:");
            foreach (Part aPart in forecast)
            {
                Console.WriteLine(aPart.PartName);
            }

           

            /*var tom = new WeatherForecast( 37);
            var bob = new WeatherForecast( 41);
            var sam = new WeatherForecast( 25);


            WeatherForecast[] value = { tom,bob,sam };
            Array.Sort(value);

            foreach (WeatherForecast weatherForecast in value)
            {
                Console.WriteLine($" {weatherForecast.Volume_24h}");
            }*/

        }
    }
}