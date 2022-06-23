// See https://aka.ms/new-console-template for more information
Thread mainThread = Thread.CurrentThread;
mainThread.Name = "Main Thread";
// Console.WriteLine(mainThread.Name);

Thread thread1 = new Thread(() => CountDown("Timer #1"));
Thread thread2 = new Thread(() => CountUp("Timer #2"));
thread1.Start();
thread2.Start();

Console.WriteLine(mainThread.Name + " is completed!");

Console.ReadKey();

static void CountDown(string timerName)
{
    for (int i = 100; i >= 0; i--)
    {
        Console.WriteLine($"{timerName} : {i} Milliseconds");
        Thread.Sleep(100);
    }
    Console.WriteLine($"{timerName} is completed!");
}

static void CountUp(string timerName)
{
    for (int i = 0; i <= 100; i++)
    {
        Console.WriteLine($"{timerName} : {i} Milliseconds");
        Thread.Sleep(100);
    }
    Console.WriteLine($"{timerName} is completed!");
}