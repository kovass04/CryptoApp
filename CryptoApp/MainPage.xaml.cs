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

        int i;
        private async void temp()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("assets.json");

            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (MyArray)JsonConvert.DeserializeObject(text, typeof(MyArray));

            List<Part> forecast = new List<Part>();

            foreach (Assets_json item in temp.Assets)
            {
                forecast.Add(new Part() { PartName = item.Asset_id, PartId = item.Volume_24h });
            }

            forecast.Sort();
            forecast.Reverse();

            foreach (Part aPart in forecast)
            {
                
                if (i == 10)
                    break;
                i++;

                if (i == 1)
                    btn1.Content = aPart.PartName;
                else if (i == 2)
                    btn2.Content = aPart.PartName;
                else if (i == 3)
                    btn3.Content = aPart.PartName;
                else if (i == 4)
                    btn4.Content = aPart.PartName;
                else if (i == 5)
                    btn5.Content = aPart.PartName;
                else if (i == 6)
                    btn6.Content = aPart.PartName;
                else if (i == 7)
                    btn7.Content = aPart.PartName;
                else if (i == 8)
                    btn8.Content = aPart.PartName;
                else if (i == 9)
                    btn9.Content = aPart.PartName;
                else if (i == 10)
                    btn10.Content = aPart.PartName;
            }

            /*foreach (WeatherForecast item in temp.Assets)
            {


                if (i == 11)
                    continue;
                i ++;

                if (i == 1)
                    btn1.Content = item.Asset_id;
                else if(i== 2)
                    btn2.Content = item.Asset_id;
                else if (i == 3)
                    btn3.Content = item.Asset_id;
                else if (i == 4)
                    btn4.Content = item.Asset_id;
                else if (i == 5)
                    btn5.Content = item.Asset_id;
                else if (i == 6)
                    btn6.Content = item.Asset_id;
                else if (i == 7)
                    btn7.Content = item.Asset_id;
                else if (i == 8)
                    btn8.Content = item.Asset_id;
                else if (i == 9)
                    btn9.Content = item.Asset_id;
                else if (i == 10)
                    btn10.Content = item.Asset_id;


                Button button = new Button();
                button.Width = 100;
                button.Height = 40;

                button.Name = "btns" + i;

                button.Content = item.Asset_id;
                //textblock.Text = Math.Round(item.Price, 2).ToString();

                button.Click += Button_Click;

                
                button.Margin = new Thickness(i * 120, 0, 0, 0);
                parentGrid1.Children.Add(button);

                

            }*/
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info pi = new Info { Asset_id = "BTS"};
            Frame.Navigate(typeof(InfoPage), pi);

            /*Info pi = new Info { Asset_id = btn1.Content.ToString() };
            Frame.Navigate(typeof(InfoPage), pi);*/

        }

        public class Info
        {
            public string Asset_id { get; set; }
        }
        public class Assets_json
        {
            public string Asset_id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
            public string Change_1h { get; set; }
            public string Change_24h { get; set; }

            public string Change_7d { get; set; }

            public double Volume_24h { get; set; }

            public string Market_cap { get; set; }

            public string Fully_diluted_market_cap { get; set; }
            public string Circulating_supply { get; set; }
            public string Total_supply { get; set; }
            public string Max_supply { get; set; }

        }
        public class MyArray
        {
            public List<Assets_json> Assets { get; set; }

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            /*Info pi = new Info {Asset_id = btn1.Content.ToString()};*/
            Frame.Navigate(typeof(InfoPage), btn1.Content);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn2.Content);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn3.Content);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn4.Content);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn5.Content);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn6.Content);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn7.Content);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn8.Content);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn9.Content);
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPage), btn10.Content);
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AssetsPage));
        }
    }

    
}
