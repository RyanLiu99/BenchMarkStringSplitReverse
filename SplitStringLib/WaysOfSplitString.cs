namespace SplitStringLib
{
    public class WaysOfSplitString
    {
        private const char space = ' ';
        private const int SupportedMaxWords = 200;

        private static Action<char[]?> Print = Console.Write;
        private static Action<char> PrintChar = Console.Write;
        private static Action<object?> PrintObject = Console.Write;
        private static Action WriteEmptyLine = Console.WriteLine;
        private static Action<string?> WriteStrLine = Console.WriteLine;

        private static Range[] Ranges = new Range[SupportedMaxWords];
      

        public static void NullActions()
        {
            Print = x => { };
            PrintChar = x => { }; ;
            PrintObject = x => { }; ;
            WriteEmptyLine = () => { };
            WriteStrLine = x => { };
        }

        public static void StringSplitJoinVersion(string input)
        {
            WriteStrLine(string.Join(space, input.Split(space, StringSplitOptions.RemoveEmptyEntries).Reverse()));
        }

        public static void SpanRangeVersion(string input)
        {
            ReadOnlySpan<char> separator = new ReadOnlySpan<char>(new[] { space });
            ReadOnlySpan<char> span = input.AsMemory().Span;

            Span<Range> ranges = new Span<Range>(Ranges); //Span<T> cannot be field
            int count = span.Split(ranges, separator, StringSplitOptions.RemoveEmptyEntries);

            for (int c = count - 1; c >= 0; c--)
            {
                var range = ranges[c];
                for (var pos = range.Start.Value; pos < range.End.Value; pos++)
                {
                    PrintChar(span[pos]);
                }

                if (c == 0)
                    WriteEmptyLine();
                else
                    PrintChar(space);
            }
        }

        public static void SpanVersion(string input)
        {
            ReadOnlySpan<char> span = input.AsSpan().Trim();
            var p = span.LastIndexOf(space);

            while (p != -1)
            {
                Print(span.Slice(p + 1).ToArray());
                span = span.Slice(0, p).Trim();
                p = span.LastIndexOf(space);
                if (span.Length > 0) { PrintChar(space); }  // Only if there are more words, print separator
            }

            if (span.Length > 0) { Print(span.ToArray()); }
            WriteEmptyLine();
        }
    }
}
