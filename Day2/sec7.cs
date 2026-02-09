using System;
namespace sec7
{
    public class SwitchExamples
    {
        public static void Show(int x)
        {
            if (x > 0)
                Console.WriteLine("pos");
            else if (x < 0)
                Console.WriteLine("neg");
            else
                Console.WriteLine("zero");
            var result = x switch
            {
                0 => "zero",
                > 0 => "positive",
                < 0 => "negative"
            };
            Console.WriteLine($"Switch result: {result}");
        }
    }
}