using CryptoApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssetsPage : Page
    {
        public AssetsPage()
        {
            this.InitializeComponent();
        }
       
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            string url = "https://cryptingup.com/api/assets";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);


            foreach (Asset item in temp.assets)
            {
                Button Asset_id_Block = new Button();
                TextBlock Name_Block = new TextBlock();
                TextBlock Price_Block = new TextBlock();
                TextBlock Change_1h_Block = new TextBlock();
                TextBlock Change_24h_Block = new TextBlock();
                TextBlock Change_7d_Block = new TextBlock();
                TextBlock Volume_24h_Block = new TextBlock();
                TextBlock Market_cap_Block = new TextBlock();
                StackPanel stackPanel = new StackPanel();

                stackPanel.Orientation = Orientation.Horizontal;

                Asset_id_Block.Content = item.asset_id;
                Asset_id_Block.Width = 80;
                Asset_id_Block.Click += Assets_info_Click;
                stackPanel.Children.Add(Asset_id_Block);

                Name_Block.Text = item.name;
                Name_Block.Width = 380;
                stackPanel.Children.Add(Name_Block);

                Price_Block.Text = "$" + string.Format("{0:f2}", item.price);
                Price_Block.Width = 140;
                stackPanel.Children.Add(Price_Block);

                Change_1h_Block.Text = string.Format("{0:f2}", item.change_1h) + "%";
                Change_1h_Block.Width = 110;
                stackPanel.Children.Add(Change_1h_Block);

                Change_24h_Block.Text = string.Format("{0:f2}", item.change_24h) + "%";
                Change_24h_Block.Width = 90;
                stackPanel.Children.Add(Change_24h_Block);

                Change_7d_Block.Text = string.Format("{0:f2}", item.change_7d) + "%";
                Change_7d_Block.Width = 100;
                stackPanel.Children.Add(Change_7d_Block);

                Volume_24h_Block.Text = "$" + string.Format("{0:f3}", item.volume_24h/1000000000) + "b";
                Volume_24h_Block.Width = 150;
                stackPanel.Children.Add(Volume_24h_Block);

                Market_cap_Block.Text = "$" + string.Format("{0:f2}", item.market_cap / 1000000000) + "b";
                Market_cap_Block.Width = 120;
                stackPanel.Children.Add(Market_cap_Block);

                AssetPanel.Children.Add(stackPanel);

            }

        }
        private void Assets_info_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Frame.Navigate(typeof(AssetsInfoPage), button.Content);

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
