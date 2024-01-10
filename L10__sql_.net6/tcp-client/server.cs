using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Lab10;
using Microsoft.EntityFrameworkCore;
using static Lab10.Program;

var tcpListener = new TcpListener(IPAddress.Any, 8080);

try
{
    tcpListener.Start(); 
    Console.WriteLine("Сервер запущен. Ожидание подключений... ");
    while (true)
    {
        var tcpClient = await tcpListener.AcceptTcpClientAsync();
        Task.Run(async () => await ProcessClientAsync(tcpClient));
    }
}
finally
{
    tcpListener.Stop();
}

async Task ProcessClientAsync(TcpClient tcpClient)
{
    var stream = tcpClient.GetStream();
    var response = new List<byte>();
    int bytesRead = 10;
    while (true)
    {
        while ((bytesRead = stream.ReadByte()) != '\n')
        {
            response.Add((byte)bytesRead);
        }
        var word = Encoding.UTF8.GetString(response.ToArray());
        if (word == "END") break;
        string res = ticker_search2(word);
        Console.WriteLine($"Клиент {tcpClient.Client.RemoteEndPoint} запросил информацию о тикере {word}");
        if (res == "") res = "не найдено в базе данных";
        res += '\n';
        await stream.WriteAsync(Encoding.UTF8.GetBytes(res));
        response.Clear();
    }
    tcpClient.Close();
}
static string ticker_search2(string ticker)
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