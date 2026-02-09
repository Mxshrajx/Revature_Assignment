using System;
using System.Diagnostics;
using System.Text;
namespace stopwatch
{
    public class PerformanceTest
    {
        public static void Compare()
        {
            const int N = 100_000;
            // Stopwatch sw1 = Stopwatch.StartNew();
            string result = "";
            for (int i = 0; i < N; i++)
            {
                result += "x";
            }
            // sw1.Stop();
            // Console.WriteLine($"+ concatenation: {sw1.ElapsedMilliseconds} ms");
            // Stopwatch sw2 = Stopwatch.StartNew();
            var sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append("x");
            }
            // string result2 = sb.ToString();
            // sw2.Stop();
            // Console.WriteLine($"StringBuilder: {sw2.ElapsedMilliseconds} ms");
        }
    }
}