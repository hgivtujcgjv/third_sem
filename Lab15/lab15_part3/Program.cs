using System;
using System.Threading;

public class SingleRandomizer
{
    private static SingleRandomizer instance;
    private static readonly object lockObject = new object();
    private readonly Random random ;

    private SingleRandomizer()
    {
        random = new Random();
    }
    //di container 
    public static SingleRandomizer Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SingleRandomizer();
                    }
                }
            }

            return instance;
        }
    }

    public int GetNextRandomNumber()
    {
        lock (lockObject)
        {
            return random.Next();
        }
    }
}

class Program
{
    static void Main()
    {
        Thread thread1 = new Thread(UseRandomizer);
        Thread thread2 = new Thread(UseRandomizer);

        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
    }

    static void UseRandomizer()
    {
        SingleRandomizer randomizer = SingleRandomizer.Instance;

        for (int i = 0; i < 5; i++)
        {
            int randomNumber = randomizer.GetNextRandomNumber();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {randomNumber}");
        }
    }
}
