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
using static CryptoApp.MainPage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExchangesPage : Page
    {
        public ExchangesPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("exchanges.json");
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (Exchanges_array)JsonConvert.DeserializeObject(text, typeof(Exchanges_array));

            foreach (Exchanges_json item in temp.Exchanges)
            {
                TextBlock textBlock = new TextBlock();
                TextBlock textBlock1 = new TextBlock();
                TextBlock textBlock2 = new TextBlock();
                HyperlinkButton hyperlinkButton = new HyperlinkButton();

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                textBlock.Text = item.Name;
                textBlock.Width = 700;

                stackPanel.Children.Add(textBlock);

                textBlock1.Text = item.Volume_24h.ToString();
                textBlock1.Width = 350;

                stackPanel.Children.Add(textBlock1);

                hyperlinkButton.Content = "Website";

                Uri uri = new Uri(item.Website);

                hyperlinkButton.NavigateUri = uri;
                /*textBlock2.Text = item.Website;
                textBlock2.Width = 100;*/

                stackPanel.Children.Add(hyperlinkButton);

                ExchangesPanel.Children.Add(stackPanel);
            }

            }
            private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AssetsPage));
        }

        private void Exchanges_Click(object sender, RoutedEventArgs e)
        {
             Frame.Navigate(typeof(ExchangesPage));
        }

        public class Exchanges_json
        {
            public string Name { get; set; }
            public string Website { get; set; }
            public double Volume_24h { get; set; }

            /*"exchange_id": "BINANCE",
              "name": "Binance",
              "website": "https://www.binance.com",
              "volume_24h": 11040425887.914703*/
        }
        public class Exchanges_array
        {
            public List<Exchanges_json> Exchanges { get; set; }

        }
    }
}
