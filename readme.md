# Run Benchmark 

- First run [unit tests](SplitStringTest/StringSplitTest1.cs)  make sure it works before measure performance
- Chose benchmark(s) to run in [Program.cs](BenchMark/Program.cs)

3 implementations under test is in [WaysOfSplitString.cs](SplitStringLib/WaysOfSplitString.cs).  


# SplitLinesBenchmarkConsoleWrite, write to console.  


| Method                 | Mean     | Error   | StdDev  | Gen0   | Allocated |
|----------------------- |---------:|--------:|--------:|-------:|----------:|
| StringSplitJoinVersion | 184.7 us | 3.59 us | 4.40 us | 0.7324 |   3.95 KB |
| SpanRangeVersion       | 212.5 us | 4.19 us | 8.28 us | 0.2441 |   1.92 KB |
| SpanVersion            | 212.3 us | 4.22 us | 6.93 us | 0.2441 |   1.92 KB |



# SplitLinesBenchmarkNoOp, does not write to console (No-op)  

Let's just test split and reverse itself, and make all Console actions a no-op.  Normally application won't print data to the console. 

| Method                 | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|----------:|
| StringSplitJoinVersion | 1,936.5 ns | 38.15 ns | 39.18 ns | 0.9651 |   3.95 KB |
| SpanRangeVersion       | 1,204.8 ns | 23.84 ns | 22.30 ns | 0.4692 |   1.92 KB |
| SpanVersion            |   713.5 ns | 14.12 ns | 15.11 ns | 0.4702 |   1.92 KB |

You can see, SpanVersion is fastest and one of the version with least memory allocation.

 # Legends  

```
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
``` 