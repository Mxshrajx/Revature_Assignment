using System;
namespace Sec2
{
    public class Args
    {
        public static void Arg(string[] arg)
        {
            Console.WriteLine(arg.Length > 0 ? arg[0] : "no args");
        }
    }
}