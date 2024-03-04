# Run Benchmark 

- First run [unit tests](SplitStringTest/StringSplitTest1.cs)  make sure it works before measure performance
- Chose benchmark to run in [Program.cs](BenchMark/Program.cs)

3 (ineed 4, see below) implementations under test is in [WaysOfSplitString.cs](SplitStringLib/WaysOfSplitString.cs).  


# SplitLinesBenchmarkConsoleWrite, write to console.  

No surprise, SpanVersion is fastest and has least memory allocation and least GC.

But StringSplitJoin version is better than SpanRange version. Really? Suspect something to do with Console.Write(). A normal application won't print to console. 

| Method                 | Mean     | Error   | StdDev   | Median   | Gen0   | Allocated |
|----------------------- |---------:|--------:|---------:|---------:|-------:|----------:|
| StringSplitJoinVersion | 221.2 us | 4.59 us | 13.24 us | 217.2 us | 0.7324 |   3.95 KB |
| SpanRangeVersion       | 463.1 us | 9.03 us | 15.57 us | 459.0 us | 0.9766 |   4.07 KB |
| SpanVersion            | 217.0 us | 4.25 us |  7.09 us | 215.9 us | 0.2441 |   1.92 KB |


# SplitLinesBenchmarkNoOp, does not write to console (No-op)  

Let's just test split and reverse itself, and make all Console actions a no-op. 
Following result makes more sense now. SpanVersion is still the best. SpanRangeVersion is the 2nd due to need create Span&lt;Range&gt; and does not reuse it. 

| Method                 | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|----------:|
| StringSplitJoinVersion | 1,870.6 ns | 36.16 ns | 48.28 ns | 0.9670 |   3.95 KB |
| SpanRangeVersion       | 1,222.3 ns | 23.20 ns | 21.70 ns | 0.3872 |   1.59 KB |
| SpanVersion            |   687.9 ns | 12.71 ns | 11.27 ns | 0.4702 |   1.92 KB |


# SplitLinesBenchmarkNoOp, but in SpanRangeVersion, it reuse Ranges place holder (move Ranges from local var to be static field, so 4th way), make it no allocation at all.
| Method                 | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|----------:|
| StringSplitJoinVersion | 1,865.9 ns | 36.68 ns | 43.66 ns | 0.9670 |    4048 B |
| SpanRangeVersion       | 1,228.5 ns | 24.41 ns | 58.95 ns |      - |         - |
| SpanVersion            |   738.2 ns | 14.74 ns | 28.39 ns | 0.4702 |    1968 B |

 # Legends  

```
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
``` 