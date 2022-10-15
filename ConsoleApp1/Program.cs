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
        public int Price { get; set; }

        public double Change_24h { get; set; }

        public float Volume_24h { get; set; }

        public string Asset_id { get; set; }


    }

    public class MyArray
    {
        public List<WeatherForecast>? Assets { get; set; }
     
    }



    public class Program
    {
        public static void Main()
        {
            string fileName = @"C:\Users\kovas\source\repos\CryptoApp\ConsoleApp1\WeatherForecast.json";
            string jsonString = File.ReadAllText(fileName);
            /*WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;

            Console.WriteLine($"Date: {weatherForecast.asset_id}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.name}");*/

            var temp = (MyArray)JsonConvert.DeserializeObject(jsonString, typeof(MyArray));

            foreach (WeatherForecast item in temp.Assets)
            {
                Console.WriteLine("Key: {0}, Value {1} ", item.Asset_id, item.Name );
            }


        }
    }
}