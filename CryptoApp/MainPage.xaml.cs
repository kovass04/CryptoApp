using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {  
            this.InitializeComponent();
            temp();
        }

        int i;
        private async void temp()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("WeatherForecast.json");

            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (MyArray)JsonConvert.DeserializeObject(text, typeof(MyArray));

            
            foreach (WeatherForecast item in temp.Assets)
            {
                if (i == 11)
                    continue;
                i ++;

                Button button = new Button();
                button.Width = 100;
                button.Height = 40;

                button.Name = "btn" + i;

                button.Content = item.Name;
                //textblock.Text = Math.Round(item.Price, 2).ToString();

                button.Click += Button_Click;

                
                button.Margin = new Thickness(i * 120, 0, 0, 0);
                parentGrid1.Children.Add(button);

                

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(InfoPage), "bts");

        }

        public class WeatherForecast
        {

            public string Name { get; set; }
            public float Price { get; set; }

            public double Change_24h { get; set; }

            public float Volume_24h { get; set; }

        }
        public class MyArray
        {
            public List<WeatherForecast> Assets { get; set; }

        }

        private async void First_Click_1(object sender, RoutedEventArgs e)
        {
         
            
            
        }
    }

    
}
