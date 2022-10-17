using CryptoApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using static CryptoApp.MainPage;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MarketsPage : Page
    {
        public MarketsPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = "https://cryptingup.com/api/markets";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);

            foreach (Market item in temp.markets)
            {
                TextBlock Symbol_Block = new TextBlock();
                TextBlock Price_Block = new TextBlock();
                TextBlock Price_unconverted_Block = new TextBlock();
                TextBlock Change_24h_Block = new TextBlock();
                TextBlock Spread_Block = new TextBlock();
                TextBlock Volume_24h_Block = new TextBlock();
                Button Exchange_id = new Button();

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;


                Symbol_Block.Text = item.symbol;
                Symbol_Block.Width = 200;
                stackPanel.Children.Add(Symbol_Block);

                Price_Block.Text = item.price.ToString() + "$";
                Price_Block.Width = 240;
                stackPanel.Children.Add(Price_Block);


                Price_unconverted_Block.Text = string.Format("{0:f2}", item.price_unconverted);
                Price_unconverted_Block.Width = 210;
                stackPanel.Children.Add(Price_unconverted_Block);

                Change_24h_Block.Text = string.Format("{0:f2}", item.change_24h) + "%";
                Change_24h_Block.Width = 140;
                stackPanel.Children.Add(Change_24h_Block);


                Spread_Block.Text = string.Format("{0:f2}", item.spread) + "%";
                Spread_Block.Width = 100;
                stackPanel.Children.Add(Spread_Block);

                Volume_24h_Block.Text = "$" + string.Format("{0:f2}", item.volume_24h/1000000000) + "b";
                Volume_24h_Block.Width = 140;
                stackPanel.Children.Add(Volume_24h_Block);

                Exchange_id.Width = 120;
                Exchange_id.Content = item.exchange_id;
                Exchange_id.Click += Exchange_id_Click;
                stackPanel.Children.Add(Exchange_id);

                MarketsPanel.Children.Add(stackPanel);

            }


            }
        private void Exchange_id_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Frame.Navigate(typeof(MarketsInfoPage), button.Content);

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AssetsPage));
        }

        private void Markets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MarketsPage));
        }

        private void Exchanges_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExchangesPage));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage));
        }
    }
}
