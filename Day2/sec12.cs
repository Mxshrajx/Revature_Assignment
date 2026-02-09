using System;
using System.Collections.Generic;
namespace sec12
{
    public class LoopExamples
    {
        public static void Show()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("For loop:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            var list = new List<string> { "a", "b", "c" };
            Console.WriteLine("\nForeach loop:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            int j = 0;
            Console.WriteLine("\nWhile loop:");
            while (j++ < 5)
            {
                Console.WriteLine($"i = {j}");
            }
        }
    }
}