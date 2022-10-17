using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using static CryptoApp.MarketsPage;
using CryptoApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent(); 
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = "https://cryptingup.com/api/assetsoverview";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);

            names = new List<Person>();

            foreach (Asset item in temp.assets)
            {
                names.Add(new Person() { asset_id = item.asset_id, name = item.name });

            }

            mylst.ItemsSource = names;
        }

        public class Person
        {
            public string name { get; set; }
            public string asset_id { get; set; }
        }
        List<Person> names;

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

        private void sbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            mylst.ItemsSource = names;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cont = from s in names where s.name.Contains(sbar.Text) select s;//LINQ Query  

            mylst.ItemsSource = cont;
        }

        private void Assets_info_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Frame.Navigate(typeof(AssetsInfoPage), button.Content);

        }

    }
}
