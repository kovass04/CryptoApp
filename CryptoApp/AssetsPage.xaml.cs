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
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("assets.json");
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            var temp = (MyArray)JsonConvert.DeserializeObject(text, typeof(MyArray));


            //have bug
            //

            foreach (Assets_json item in temp.Assets)
            {

                /*test1.Text = item.Asset_id;
                test2.Text = item.Name;
                test3.Text = item.Change_1h;
                test4.Text = item.Change_24h;
                test5.Text = item.Change_7d;
                test6.Text = item.Market_cap;*/

                //Button button = new Button();
                TextBlock textBlock = new TextBlock();
                TextBlock textBlock1 = new TextBlock();
                TextBlock textBlock2 = new TextBlock();
                TextBlock textBlock3 = new TextBlock();
                TextBlock textBlock4 = new TextBlock();
                TextBlock textBlock5 = new TextBlock();
                //button.Name = "btns" + i;

                //textBlock.Text = item.Asset_id;


                //button.Click += Button_Click;

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                
                //.Children.Add(textBlock);
                textBlock.Text = item.Asset_id;
                textBlock.Width = 480;
                //button.Margin = new Thickness(i * 120, 0, 0, 0);
                stackPanel.Children.Add(textBlock);
                textBlock1.Text = item.Name;
                textBlock1.Width = 190;
                stackPanel.Children.Add(textBlock1);

                if(item.Change_1h.Length>=5)
                    textBlock2.Text = item.Change_1h.Substring(0, item.Change_1h.Length - 13);
                else
                    textBlock2.Text = item.Change_1h;

                textBlock2.Width = 120;
                stackPanel.Children.Add(textBlock2);

                if (item.Change_24h.Length >= 5)
                    textBlock3.Text = item.Change_24h.Substring(0, item.Change_24h.Length - 13);
                else
                    textBlock3.Text = item.Change_24h;

                textBlock3.Width = 100;
                stackPanel.Children.Add(textBlock3);

                if (item.Change_7d.Length >= 5)
                    textBlock4.Text = item.Change_7d.Substring(0, item.Change_7d.Length - 13);
                else
                    textBlock4.Text = item.Change_7d;

                textBlock4.Width = 120;
                stackPanel.Children.Add(textBlock4);

                //
                //volume 24
                //
                //add Market_cap in billion price
                textBlock5.Text = item.Market_cap;
                textBlock5.Width = 120;
                stackPanel.Children.Add(textBlock5);

                AssetPanel.Children.Add(stackPanel);



            }

        }
            private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
