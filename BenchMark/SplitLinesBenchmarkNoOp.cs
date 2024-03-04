using BenchmarkDotNet.Attributes;
using SplitStringLib;

[RPlotExporter]
[MemoryDiagnoser]
public class SplitLinesBenchmarkNoOp
{
    [GlobalSetup]
    public void Setup()
    {
        WaysOfSplitString.NullActions();
    }

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
