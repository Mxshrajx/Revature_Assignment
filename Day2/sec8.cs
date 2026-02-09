using System;
namespace sec8
{
    public class PatternMatching
    {
        public static void Show()
        {
            object o = 5;
            if (o is int i)
                Console.WriteLine(i + 1);
            var person = new { Name = "Alice", Age = 20 };
            if (person is { Age: >= 18, Name: var n })
                Console.WriteLine(n);
            Console.WriteLine(Describe(null));     
            Console.WriteLine(Describe(42));      
            Console.WriteLine(Describe("hello"));  
            Console.WriteLine(Describe(3.14)); 
        }
        static string Describe(object? obj) =>
            obj switch
            {
                null => "none",
                int i => $"int {i}",
                string s => $"str({s})",
                _ => "other"
            };
    }
}