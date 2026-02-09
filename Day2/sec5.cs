using System;
using System.Collections.Generic;
namespace sec5
{
    public class VarTypes
    {
        public static void Show()
        {
            var x = 10;           
            var list = new List<string>(); 
            Console.WriteLine($"Type of x: {x.GetType()}");
            Console.WriteLine($"Type of list: {list.GetType()}");
        }
    }
}