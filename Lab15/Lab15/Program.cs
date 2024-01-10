using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;

public class DirectoryWatcher
{
    private readonly string directoryPath;
    private HashSet<string> files;

    public event Action<HashSet<string>, HashSet<string>> DirectoryChanged;

    private readonly Timer timer;

    public DirectoryWatcher(string directoryPath)
    {
        this.directoryPath = directoryPath;
        this.files = GetFilesInDirectory();
        timer = new Timer();
        timer.Interval = 5000;
        timer.Elapsed += TimerElapsed;
    }

    private HashSet<string> GetFilesInDirectory()
    {
        return new HashSet<string>(Directory.GetFiles(directoryPath));
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        CheckDirectory();
    }

    private void CheckDirectory()
    {
        HashSet<string> currentFiles = GetFilesInDirectory();

        HashSet<string> addedFiles = new HashSet<string>(currentFiles.Except(files));
        HashSet<string> removedFiles = new HashSet<string>(files.Except(currentFiles));

        if (addedFiles.Count > 0 || removedFiles.Count > 0)
        {
            DirectoryChanged?.Invoke(addedFiles, removedFiles);
            files = currentFiles;
        }
    }

    public void StartWatching()
    {
        timer.Start();
    }

    public void StopWatching()
    {
        timer.Stop();
    }
}

class Program
{
    static void Main()
    {
        var directoryWatcher = new DirectoryWatcher(@"D:\");
        directoryWatcher.DirectoryChanged += DirectoryChangedHandler;
        directoryWatcher.StartWatching();
        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
        directoryWatcher.StopWatching();
    }

    private static void DirectoryChangedHandler(HashSet<string> addedFiles, HashSet<string> removedFiles)
    {
        Console.WriteLine("Directory changed:");
        Console.WriteLine("Added files: " + string.Join(", ", addedFiles));
        Console.WriteLine("Removed files: " + string.Join(", ", removedFiles));
    }
}
