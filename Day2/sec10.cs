using System;
namespace sec10
{
    public class ArithmeticExamples
    {
        public static void Show()
        {
            int a = 5;
            int b = 10;
            int sum = a + b;
            Console.WriteLine($"sum = {sum}");
            int numerator = 7;
            int denominator = 2;
            double ratio = (double)numerator / denominator;
            Console.WriteLine($"ratio = {ratio}");
            int r = 7 % 3;
            Console.WriteLine($"r = {r}");
        }
    }
}