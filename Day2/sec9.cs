using System;
namespace sec9
{
    public class LogicExamples
    {
        public static void Show()
        {
            int x = 42;
            bool isReady = false;
            bool hasData = false;
            if (x > 0 && x < 100)
            {
                Console.WriteLine("x is in range");
            }
            if (!(isReady || hasData))
            {
                Console.WriteLine("Not ready and no data");
            }
            string a = "hi";
            bool eq = a == "hi";
            Console.WriteLine($"eq = {eq}");
        }
    }
}