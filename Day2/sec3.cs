using System;
namespace sec3
{
    public class Variables
    {
        public static void Show()
        {
            int a = 42;
            long big = 3_000_000_000L;
            float f = 3.14f;
            double d = 2.71828;
            decimal money = 19.99m;
            bool ok = true;
            char letter = 'A';

            Console.WriteLine($"int a = {a}");
            Console.WriteLine($"long big = {big}");
            Console.WriteLine($"float f = {f}");
            Console.WriteLine($"double d = {d}");
            Console.WriteLine($"decimal money = {money}");
            Console.WriteLine($"bool ok = {ok}");
            Console.WriteLine($"char letter = {letter}");
        }
    }
}