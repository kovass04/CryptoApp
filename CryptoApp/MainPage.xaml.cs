using CryptoApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;


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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = "https://cryptingup.com/api/assets";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);


            List<Part> sort_list = new List<Part>();

            foreach (Asset item in temp.assets)
            {
                sort_list.Add(new Part() { PartName = item.asset_id, PartId = item.volume_24h });
            }

            sort_list.Sort();
            sort_list.Reverse();

            foreach (Part aPart in sort_list)
            {
                if (i == 10)
                    break;
                i++;
                Button button = new Button();
                button.Content = aPart.PartName;
                button.Width = 100;
                button.Height = 40;
                button.Click += Button_Click;
                button.Margin = new Thickness(i * 110, 0, 0, 0);
                canvas_btn.Children.Add(button);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Frame.Navigate(typeof(InfoPage), button.Content);
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AssetsPage));
        }

        private void Exchanges_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExchangesPage));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Markets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MarketsPage));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage));
        }
    }

    
}
