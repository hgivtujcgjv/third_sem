
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
//D:\projects_c#
//test_l8.txt


class Program
{

    async Task CompressAsync(string sourceFile, string compressedFile)
    {
        using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
        using FileStream targetStream = File.Create(compressedFile);
        using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
        await sourceStream.CopyToAsync(compressionStream);
        Console.WriteLine($"Сжатие файла {sourceFile} завершено.");
        Console.WriteLine($"Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}");
    }
    static async Task Main(string[] args)
    {
       string file_name = Console.ReadLine();
       string dir_path = Console.ReadLine();
       string full_path = Path.Combine(dir_path, file_name);
       string sourceFile = "D:\\projects_c#\\build.txt"; // исходный файл
       string compressedFile = "D:\\projects_c#\\build.gz";
        try
        {
            string[] foundFiles = Directory.GetFiles(dir_path, file_name, SearchOption.AllDirectories);
            if (foundFiles.Length > 0)
            {
                foreach (var i in foundFiles)
                {
                    Console.WriteLine($"Найден файл: {i}");
                    using (FileStream fs = File.OpenRead(i))
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        byte[] buffer = new byte[fs.Length];
                        await fs.ReadAsync(buffer, 0, buffer.Length);
                        string textFromFile = Encoding.Default.GetString(buffer);
                        Console.WriteLine($"Текст из файла: {textFromFile}");
                    }
                }
            }
            var programInstance = new Program();
            await programInstance.CompressAsync(full_path, compressedFile);
        }
        catch (Exception o) {
            Console.WriteLine($"Ошибка при поиске файла: {o.Message}");
        }

    }
}

