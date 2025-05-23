using static System.Console;

namespace AsyncLearning.Examples;

public static class TestYeldReturn
{
    public static void Run()
    {
        RunComparation newRun = new();
        newRun.UseNoYieldDemo();
        newRun.UseYieldDemo();
    }
}

public class RunComparation
{

    private IEnumerable<int> NoYieldDemo()
    {
        List<int> result = [1, 2];
        return result;
    }
    private IEnumerable<int> YieldDemo()
    {
        yield return 1;
        yield return 2;
    }
    public void UseNoYieldDemo()
    {
        foreach (var value in NoYieldDemo())
        {
            WriteLine($"Got {value}");
        }
    }
    public void UseYieldDemo()
    {
        foreach (var value in YieldDemo())
        {
            WriteLine($"Got {value}");
        }
    }
}