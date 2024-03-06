
using BenchmarkDotNet.Running;

public class Program
{
    internal const string Input = "A web application that generates random text that you can use   in Sample web pages or  typography samples.  A web application that generates random text that you can use   in Sample web pages or  typography samples. A web application that generates random text that you can use   in Sample web pages or  typography samples.";

    public static void Main(string[] args)
    {      
        BenchmarkRunner.Run<SplitLinesBenchmarkConsoleWrite>();
        BenchmarkRunner.Run<SplitLinesBenchmarkNoOp>();
    }
}