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
using static CryptoApp.MainPage;
using static System.Net.WebRequestMethods;

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
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("assets.json");
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (MyArray)JsonConvert.DeserializeObject(text, typeof(MyArray));
            
            if (e.Parameter != null)
            {
                /*Info pi = (Info)e.Parameter;*/

                foreach (Assets_json item in temp.Assets)
                {
                    if(e.Parameter.ToString() == item.Asset_id)
                    {
                        Name.Text = item.Name.ToString();
                        Asset_id.Text = item.Asset_id.ToString();
                        Price.Text = "$" + item.Price.ToString();
                        Change_1h.Text = item.Change_1h + "%";
                        Change_24h.Text = item.Change_24h.ToString() + "%";
                        Change_7d.Text = item.Change_7d + "%";
                        Market_cap.Text = item.Market_cap;
                        Fully_diluted_market_cap.Text = item.Fully_diluted_market_cap;
                        Circulating_supply.Text = item.Circulating_supply;
                        Total_supply.Text = item.Total_supply;
                        Max_supply.Text = item.Max_supply;
                        break;
                    }
                    
                }
                
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
