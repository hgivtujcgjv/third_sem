using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class LogRepository
{
    private List<string> logs = new List<string>();

    public void AddLog(string log)
    {
        logs.Add(log);
    }

    public List<string> GetAllLogs()
    {
        return new List<string>(logs);
    }
}
public class DatabaseLogRepository
{
    public void SaveLogToDatabase(string log)
    {
        Console.WriteLine($"Saved log to database: {log}");
    }
}

public class MyLogger
{
    private readonly LogRepository logRepository;
    private readonly DatabaseLogRepository databaseLogRepository;

    public MyLogger(LogRepository logRepository, DatabaseLogRepository databaseLogRepository)
    {
        this.logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        this.databaseLogRepository = databaseLogRepository ?? throw new ArgumentNullException(nameof(databaseLogRepository));
    }

    public void Log(string message)
    {
        LogToFile(message);
        LogToJsonFile(message);
        LogToDatabase(message);
    }

    private void LogToFile(string message)
    {
        string logFilePath = "log.txt";
        File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
    }

    private void LogToJsonFile(string message)
    {
        string jsonLogFilePath = "log.json";
        List<string> logs = logRepository.GetAllLogs();
        logs.Add(message);
        string jsonContent = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(jsonLogFilePath, jsonContent);
    }

    private void LogToDatabase(string message)
    {
        logRepository.AddLog(message);
        databaseLogRepository.SaveLogToDatabase(message);
    }
}

class Program
{
    static void Main()
    {
        var logRepository = new LogRepository();
        var databaseLogRepository = new DatabaseLogRepository();
        var myLogger = new MyLogger(logRepository, databaseLogRepository);
        myLogger.Log("This is a log message.");
        myLogger.Log("Another log message.");
        myLogger.Log("Yet another log message.");
        Console.WriteLine("All logs:");
        foreach (var log in logRepository.GetAllLogs())
        {
            Console.WriteLine(log);
        }
    }
}
