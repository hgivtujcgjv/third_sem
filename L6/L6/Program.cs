using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;



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


namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string api = "dd4fb111da4dad7f6d5853c15f5448ea";
            int numberOfDataPoints = 50;
            Random random = new Random();
            List<Weather> mas = new List<Weather>(50);

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                double latitude = random.NextDouble() * (90.0 - (-90.0)) + (-90.0);
                double longitude = random.NextDouble() * (180.0 - (-180.0)) + (-180.0);
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid={api}";

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                Weather weatherResponse = JsonConvert.DeserializeObject<Weather>(response);
                if (weatherResponse.name is null || weatherResponse.sys.country is null)
                {
                    --i;
                }
                else
                {
                    mas.Add(weatherResponse);
                }
            }
            for (int i = 0;i < mas.Count;i++)
            {
                Console.WriteLine($"Country: {mas[i].sys.country}, Temp in {mas[i].name}: {mas[i].main.temp} C, Description: {mas[i].weather[0].description}");
            }
            var orderedList = mas.OrderBy(p => p.main.temp).ToList();
            mas.Max(x=>x.main.temp);
            mas.Min(x=>x.main.temp);
            List<Weather> list = (List<Weather>)orderedList;
            List<Weather> list2 = (List<Weather>)orderedList;
            List<Weather> list3 = (List<Weather>)orderedList;
            Console.WriteLine("\n\n\n\n\nЗаново отсортированный список по возрастанию температуры");
            foreach (var i in list) {
                    Console.WriteLine($"Country: {i.sys.country}, Temp in {i.name}: {i.main.temp} C, Description: {i.weather[0].description}");
            }
            double midle_temp = 0;
            foreach (var i in list) {
                midle_temp += i.main.temp;
            }
            double result = midle_temp / (double)list.Count;
            int result2 = list2.Select(weather => weather.sys.country).Distinct().Count();
            var result3 = list3.First(mweather => mweather.weather[0].description == "clear sky");
            var result4 = list3.First(mweather => mweather.weather[0].description == "light rain");
            var result5 = list3.First(mweather => mweather.weather[0].description == "few clouds");
            Console.WriteLine("\n\n\n\n\nСтрана с самой большой и самой низкой температурой, а так же средняя температура");
            Console.WriteLine($"Country: {list[0].sys.country}, Temp in {list[0].name}: {list[0].main.temp} C, Description: {list[0].weather[0].description}");
            Console.WriteLine($"Country: {list[49].sys.country}, Temp in {list[49].name}: {list[49].main.temp} C, Description: {list[49].weather[0].description}");
            Console.WriteLine($"Средняя температура равна : {result}, Количество стран в колекции {result2} , Первая страна с читсым небом {result3.name}, {result3.sys.country}");
            Console.WriteLine($"Первая страна с дождем {result4.name}, {result4.sys.country} , А так же первая страна где немного облачно {result5.name}, {result5.sys.country}");
        }
    }
}









