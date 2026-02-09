using System;
namespace sec6
{
    public class NullExamples
    {
        public static void Show()
        {
            int? n = null;                     
            int value = n ?? -1;               
            string s = null;                   
            int? length = s?.Length;          
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"value = {value}");
            Console.WriteLine($"length = {length}");
        }
    }
}