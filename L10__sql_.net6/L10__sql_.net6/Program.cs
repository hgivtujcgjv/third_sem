using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;


namespace Lab10
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\projects_c#\\L10__sql_.net6\\L10__sql_.net6\\Databaseforl10.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            List<TodaysConditionprocessed> conditions = new List<TodaysConditionprocessed>();
            try
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                string query = "SELECT * FROM StockPrices";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int total = reader.GetInt32(8);
                            TodaysConditionprocessed tc = new TodaysConditionprocessed
                            {
                                Id = id,
                                Ticker = name,
                                total_state = total
                            };
                            conditions.Add(tc);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connecting");
                }
            }
            Console.WriteLine(ticker_search2("AAPL"));
            // await maincode();
            for (int i = 0; i < conditions.Count - 1; ++i)
            {
                if (conditions[i].Ticker == conditions[i + 1].Ticker)
                {
                    pred(conditions[i].total_state, conditions[i + 1].total_state);
                }
                else { }
            }
            using (var context2 = new TodaysConditionContext())
            {
                foreach (var condition in conditions)
                {
                    context2.TodaysCondition.Add(new TodaysCondition
                    {
                        Ticker = condition.Ticker,
                        state = pred(condition.total_state, condition.total_state)
                    });
                }
                context2.SaveChanges();
            }
            //Console.ReadLine();
        }
        
        static void ticker_search(string ticker)
        {
            using (var context = new TodaysConditionContext())
            {
                var selectedTickers = from condition in context.TodaysCondition
                                      where condition.Ticker == ticker
                                      select condition;

                foreach (var condition in selectedTickers)
                {
                    Console.WriteLine($"Id: {condition.Id}, Ticker: {condition.Ticker}, State: {condition.state}");
                }
            }
        }
        static async Task maincode()
        {
            string file_path = "D:\\ticker.txt";
            string[] ticker_codes = File.ReadAllLines(file_path);
            ConcurrentBag<string> results = new ConcurrentBag<string>();
            List<Task> tasks = new List<Task>();
            foreach (string ticker_code in ticker_codes)
            {
                tasks.Add(Task.Run(async () =>
                {
                    string url = get_url(ticker_code);
                    string res = await Respon(url);
                    if (res != null && !string.IsNullOrEmpty(res))
                    {
                        double averagePrice = CalculateAveragePrice(res, ticker_code);
                        results.Add($"{ticker_code}:{averagePrice}");
                    }
                }));
            }
            await Task.WhenAll(tasks);
        }

        static string pred(int x1, int x2)
        {
            if (x1 > x2) return "акции упали";
            else if (x1 < x2) return "акции выросли";
            else return "акции не изменились";
        }
        static string get_url(string ticker_code)
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = end_date.AddDays(-1);
            long start_date_unix = ((DateTimeOffset)start_date).ToUnixTimeSeconds();
            long end_date_unix = ((DateTimeOffset)end_date).ToUnixTimeSeconds();
            string url = $"https://query1.finance.yahoo.com/v7/finance/download/{ticker_code}?period1={start_date_unix}&period2={end_date_unix}&interval=1d&events=history&includeAdjustedClose=true";
            return url;
        }

        public static int CalculateTickerHash(string ticker)
        {
            using (var md5 = MD5.Create())
            {
                byte[] tickerBytes = Encoding.UTF8.GetBytes(ticker);
                byte[] hashBytes = md5.ComputeHash(tickerBytes);
                int hashValue = BitConverter.ToInt32(hashBytes, 0);
                return hashValue;
            }
        }
        async static Task<string> Respon(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
        static double CalculateAveragePrice(string res, string ticker)
        {
            string[] lines = res.Split('\n');
            double totalAveragePrice = 0.0;
            int count = 0;
            foreach (var i in lines.Skip(1))
            {
                string[] values = i.Split(',');
                if (values.Length >= 7 && !string.IsNullOrEmpty(values[0]) && !string.IsNullOrEmpty(values[1]))
                {
                    if (double.TryParse(values[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double open)
                        && double.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double high)
                        && double.TryParse(values[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double low)
                        && double.TryParse(values[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double close)
                        && double.TryParse(values[5], NumberStyles.Any, CultureInfo.InvariantCulture, out double adjClose)
                        && int.TryParse(values[6], NumberStyles.Any, CultureInfo.InvariantCulture, out int volume))
                    {
                        double Averageprice = (open + high) / 2;
                        count++;
                        totalAveragePrice += Averageprice;
                        StockPrice stockPrice = new StockPrice
                        {
                            Id = CalculateTickerHash(ticker),
                            Ticker = ticker,
                            Date = DateTime.Parse(values[0]),
                            Open = open,
                            High = high,
                            Low = low,
                            Close = close,
                            AdjustedClose = adjClose,
                            Volume = volume
                        };
                        using (var context = new StockPricesContext())
                        {
                            context.StockPrices.Add(stockPrice);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            if (count > 0)
            {
                return totalAveragePrice;
            }
            else
            {
                return 0;
            }
        }

        public static string ticker_search2(string ticker)
        {
            using (var context = new StockPricesContext())
            {
                StockPrice selectedTicker = (from condition in context.StockPrices
                                             where condition.Ticker == ticker
                                             select condition).FirstOrDefault();
                string res = ($"Id: {selectedTicker.Id}, Ticker: {selectedTicker.Ticker}, State: {selectedTicker.AveragePrice}");
                return res;
            }
        }
        public class StockPrice
        {
            [Key]
            public int Id { get; set; }
            public string Ticker { get; set; }
            public DateTime Date { get; set; }
            public double Open { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Close { get; set; }
            public double AdjustedClose { get; set; }
            public int Volume { get; set; }

            public double AveragePrice => (Open + High) / 2;
        }

        public class TodaysCondition
        {
            [Key]
            public int Id { get; set; }
            public string Ticker { get; set; }
            public string state { get; set; }

        }
        public class TodaysConditionprocessed
        {
            public int Id { get; set; }
            public string Ticker { get; set; }
            public int total_state { get; set; }

        }
        public class TodaysConditionContext : DbContext
        {
            public DbSet<TodaysCondition> TodaysCondition { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\projects_c#\\L10__sql_.net6\\L10__sql_.net6\\Databaseforl10.mdf;Integrated Security=True");
                }
            }
        }
        public class StockPricesContext : DbContext
        {
            public DbSet<StockPrice> StockPrices { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\projects_c#\\L10__sql_.net6\\L10__sql_.net6\\Databaseforl10.mdf;Integrated Security=True");
                }
            }
        }
    }
}