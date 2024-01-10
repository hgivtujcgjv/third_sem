using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.Http;
using static L9_APP_FOR_STOCKS.MainWindow;

namespace L9_APP_FOR_STOCKS
{

    public partial class MainWindow : Window
    {
        int selecteditem_index = -1;
        List<Weather> ml = new List<Weather>();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListView.SelectedItems.Count > 0)
            {
                selecteditem_index = myListView.SelectedIndex;
            }
        }
        public async Task Initialize()
        {
            await Listview_matching(ml);

            foreach (Weather weather in ml)
            {
                myListView.Items.Add(weather.name);
            }

            DoubleAnimation btn = new DoubleAnimation();
            btn.From = 0;
            btn.To = 180;
            btn.Duration = TimeSpan.FromSeconds(5);
            City_button.BeginAnimation(Button.WidthProperty, btn);
        }
        public class Weather
        {
            public MainInfo main { get; set; }
            public SysInfo sys { get; set; }
            public WeatherDescription[] weather { get; set; }
            public string name { get; set; }
        }

        public class MainInfo
        {
            public double temp { get; set; }
        }

        public class WeatherDescription
        {
            public string description { get; set; }
        }

        public class SysInfo
        {
            public string country { get; set; }
        }
        static async public Task Listview_matching(List<Weather> mas)
        {
            string api = "dd4fb111da4dad7f6d5853c15f5448ea";
            int numberOfDataPoints = 50;
            Random random = new Random();
            List<Task> downloadTasks = new List<Task>();
            for (int i = 0; i < numberOfDataPoints; i++)
            {
                double latitude = random.NextDouble() * (90.0 - (-90.0)) + (-90.0);
                double longitude = random.NextDouble() * (180.0 - (-180.0)) + (-180.0);
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid={api}";
                downloadTasks.Add(Task.Run(async () =>
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            Weather weatherResponse = JsonConvert.DeserializeObject<Weather>(responseContent);
                            if (weatherResponse.name != null && weatherResponse.sys.country != null)
                            {
                                lock (mas)
                                {
                                    mas.Add(weatherResponse);

                                }
                            }
                            else {
                                --i;
                            }
                        }
                    }
                }));
                await Task.WhenAll(downloadTasks);
            }
        }

        private void City_button_Click(object sender, RoutedEventArgs e)
        {
            if (selecteditem_index != -1)
            {
                Second_ml.Items.Add(ml[selecteditem_index].name);
                Second_ml.Items.Add(ml[selecteditem_index].sys.country);
                Second_ml.Items.Add(ml[selecteditem_index].weather[0].description);
                Second_ml.Items.Add(ml[selecteditem_index].main.temp);
            }
            else
            {
                
            }
        }
    }
}
