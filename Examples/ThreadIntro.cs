using System.Threading;
using static System.Console;
namespace AsyncLearning.Examples;

public static class ThreadIntro
{
    public static void Run()
    {
        Thread[] threads = new Thread[100];
        for (int i = 0; i < threads.Count(); i++)
        {
            threads[i] = new Thread(DoSomething);
            threads[i].Start();
        }
    }
    private static void DoSomething(object? param)
    {
        WriteLine($"Im doing something !: {param}");
    }
}