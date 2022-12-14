using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using static CryptoApp.MainPage;
using static System.Net.WebRequestMethods;
using CryptoApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InfoPage : Page
    {
        public InfoPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = "https://cryptingup.com/api/assets";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var temp = JsonConvert.DeserializeObject<Rootobject>(response);

            if (e.Parameter != null)
            {
                foreach (Asset item in temp.assets)
                {
                    if (e.Parameter.ToString() == item.asset_id)
                    {
                        Name.Text = item.name.ToString();
                        Asset_id.Text = item.asset_id.ToString();
                        Price.Text = "$" + item.price.ToString();
                        Change_1h.Text = string.Format("{0:f2}", item.change_1h) + "%";
                        Change_24h.Text = string.Format("{0:f2}", item.change_24h) + "%";
                        Change_7d.Text = string.Format("{0:f2}", item.change_7d) + "%";
                        Volume_24h.Text = "$" + string.Format("{0:f0}", item.volume_24h);
                        Market_cap.Text = "$" + string.Format("{0:f0}", item.market_cap) ;
                        Fully_diluted_market_cap.Text = "$" + string.Format("{0:f0}", item.fully_diluted_market_cap) ;
                        Circulating_supply.Text = string.Format("{0:f0}", item.circulating_supply);
                        Total_supply.Text = string.Format("{0:f0}", item.total_supply);
                        Max_supply.Text = string.Format("{0:f0}", item.max_supply);
                        break;
                    }

                }

            }


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
