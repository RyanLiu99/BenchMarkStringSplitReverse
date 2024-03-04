using BenchmarkDotNet.Attributes;
using SplitStringLib;


[MemoryDiagnoser]
public class SplitLinesBenchmarkConsoleWrite
{    
  
    [Benchmark]
    public void StringSplitJoinVersion()
    {
        WaysOfSplitString.StringSplitJoinVersion(Program.Input);
    }

    [Benchmark]
    public void SpanRangeVersion()
    {
        WaysOfSplitString.SpanRangeVersion(Program.Input);
    }


    [Benchmark]
    public void SpanVersion()
    {
        WaysOfSplitString.SpanVersion(Program.Input);
    }
}
