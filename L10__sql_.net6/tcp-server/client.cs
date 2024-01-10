using System.Net.Sockets;
using System.Text;

var words = new string[] { "AAPL", "AZ", "AWRE", "ANAB" };

using TcpClient tcpClient = new TcpClient();
await tcpClient.ConnectAsync("192.168.56.1", port: 8080);
var stream = tcpClient.GetStream();
var response = new List<byte>();
int bytesRead = 10; 
foreach (var word in words)
{
    byte[] data = Encoding.UTF8.GetBytes(word + '\n');
    await stream.WriteAsync(data);
    while ((bytesRead = stream.ReadByte()) != '\n')
    {
        response.Add((byte)bytesRead);
    }
    var translation = Encoding.UTF8.GetString(response.ToArray());
    Console.WriteLine($"Слово {word}: {translation}");
    response.Clear();
    await Task.Delay(2000);
}

await stream.WriteAsync(Encoding.UTF8.GetBytes("END\n"));