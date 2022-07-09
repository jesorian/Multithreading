// See https://aka.ms/new-console-template for more information

var startTime = DateTime.UtcNow;

var threads = ThreadSpawner(150000);

foreach (Thread machineThread in threads)
{
    machineThread.Join();
}

var endTime = DateTime.UtcNow;
Console.WriteLine($"Completed : Time {endTime - startTime}");
Console.ReadKey();

static void CountDown(string timerName, int sleepTime, int numberOfTaskToDo)
{
    for (int i = numberOfTaskToDo; i >= 0; i--)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} : Counting Down Job # {i}");
        Thread.Sleep(sleepTime);
    }
    Console.WriteLine($"{Thread.CurrentThread.Name} is completed!");
}

static void CountUp(string timerName, int sleepTime, int numberOfTaskToDo)
{
    for (int i = 0; i <= numberOfTaskToDo; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} : Counting Up Job # {i}");
        Thread.Sleep(sleepTime);
    }
    Console.WriteLine($"{Thread.CurrentThread.Name} is completed!");
}

static List<Thread> ThreadSpawner(int numberOfThreads)
{
    var threads = new List<Thread>();
    Random r = new Random();

    for (int i = 1; i <= numberOfThreads; i++)
    {
        int randomSleepTime = r.Next(500, 2500);
        int randomTaskNumber = r.Next(1, 10);
        // 0 is CountDown
        // 1 is CountUp
        int countStyle = r.Next(0, 100);

        switch (countStyle)
        {
            case >= 50:
                Thread threadCountDown = new Thread(() => CountDown($"Thread runner #{i}", randomSleepTime, randomTaskNumber));
                threadCountDown.Name = $"Thread # {i}";
                threads.Add(threadCountDown);
                threadCountDown.Start();
                break;
            default:
                Thread threadCountUp = new Thread(() => CountUp($"Thread runner #{i}", randomSleepTime, randomTaskNumber));
                threadCountUp.Name = $"Thread # {i}";
                threads.Add(threadCountUp);
                threadCountUp.Start();
                break;
        }
    }

    return threads;
}