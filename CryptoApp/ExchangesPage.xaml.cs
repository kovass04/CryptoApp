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
using static CryptoApp.MainPage;
using CryptoApp.Model;

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
            string url = "https://cryptingup.com/api/exchanges";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);

            foreach (Exchange item in temp.exchanges)
            {
                TextBlock Name_Block = new TextBlock();
                TextBlock Volume_24_Block = new TextBlock();
                HyperlinkButton hyperlinkButton = new HyperlinkButton();

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                Name_Block.Text = item.name;
                Name_Block.Width = 700;
                stackPanel.Children.Add(Name_Block);

                Volume_24_Block.Text = "$" + string.Format("{0:f0}", item.volume_24h);
                Volume_24_Block.Width = 350;
                stackPanel.Children.Add(Volume_24_Block);

                hyperlinkButton.Content = "Website";

                Uri uri = new Uri(item.website);

                hyperlinkButton.NavigateUri = uri;
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
