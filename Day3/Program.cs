using OutPara;
using IsPalindrome1;
class Program
{
    static void Main()
    {
        int[] nums = { 3, 7, 2, 9, 4 };
        if (MaxFinder.TryFindMax(nums, out int max))
            Console.WriteLine($"Max = {max}");
        else
            Console.WriteLine("Array is empty");

        string s1 = "hellolleh";
        string s2 = "hello";
        string s3 = "I am ma I";
        Console.WriteLine($"{s1} -> {s1.IsPalindrome()}");
        Console.WriteLine($"{s2} -> {s2.IsPalindrome()}");
        Console.WriteLine($"{s3} -> {s3.IsPalindrome()}");
    }
}