using System;
using System.Text;
namespace sec4
{
    public class StringsExample
    {
        public static void Show()
        {
            string s = "Hello" + " World";
            string template = $"User: {Environment.UserName}, Date: {DateTime.Today:d}";
            var sb = new StringBuilder();
            sb.Append("Line1").AppendLine();
            sb.AppendFormat("{0} items", 5);
            string result = sb.ToString();
            Console.WriteLine(s);
            Console.WriteLine(template);
            Console.WriteLine(result);
        }
    }
}