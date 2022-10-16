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
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("markets.json");
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (Markets_array)JsonConvert.DeserializeObject(text, typeof(Markets_array));

            foreach (Markets_json item in temp.Markets)
            {
                TextBlock textBlock = new TextBlock();
                TextBlock textBlock1 = new TextBlock();
                TextBlock textBlock2 = new TextBlock();
                TextBlock textBlock3 = new TextBlock();
                TextBlock textBlock4 = new TextBlock();
                TextBlock textBlock5 = new TextBlock();
                Button button = new Button();


                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;


                textBlock.Text = item.Symbol;
                textBlock.Width = 200;

                stackPanel.Children.Add(textBlock);
                textBlock1.Text = item.Price.ToString() + "$";
                textBlock1.Width = 240;
                stackPanel.Children.Add(textBlock1);


                textBlock2.Text = string.Format("{0:f2}", item.Price_unconverted);


 

                textBlock2.Width = 210;
                stackPanel.Children.Add(textBlock2);

                /*if (item.Change_24h.Length >= 5)
                    textBlock3.Text = item.Change_24h.Substring(0, item.Change_24h.Length - 13);
                else*/
                    textBlock3.Text = item.Change_24h.Substring(0, item.Change_24h.Length - 13) + "%";

                textBlock3.Width = 140;
                stackPanel.Children.Add(textBlock3);

               
                textBlock4.Text = string.Format("{0:f2}", item.Spread) + "%";

                textBlock4.Width = 100;
                stackPanel.Children.Add(textBlock4);

                //
                //volume 24
                //
                //add Market_cap in billion price
                textBlock5.Text = string.Format("{0:f0}", item.Volume_24h) + "$";
                textBlock5.Width = 140;
                stackPanel.Children.Add(textBlock5);


                button.Width = 120;
                button.Content = item.Exchange_id;

                button.Click += Exchange_id_Click;

                stackPanel.Children.Add(button);

                MarketsPanel.Children.Add(stackPanel);

            }


            }
       
        private void Exchange_id_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
   

            Frame.Navigate(typeof(MainPage), button.Content);

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

        public class Markets_json
        {
            public string Symbol { get; set; }
            public float Price { get; set; }
            public double Price_unconverted { get; set; }
            public string Change_24h { get; set; }
            public double Spread { get; set; }
            public double Volume_24h { get; set; }
            public string Exchange_id { get; set; }


      /*"exchange_id": "BINANCE",
      "symbol": "BTC-USDT",
      "base_asset": "BTC",
      "quote_asset": "USDT",
      "price_unconverted": 19114.455,
      "price": 19114.359425989467,
      "change_24h": 0.07348005960080194,
      "spread": 0.0024588418645425385,
      "volume_24h": 4668527102.607471,
      "status": "recent",
      "created_at": "2021-09-21T01:21:25",
      "updated_at": "2022-10-12T15:31:37.175188"*/
    
        }
        public class Markets_array
        {
            public List<Markets_json> Markets { get; set; }

        }
    }
}
