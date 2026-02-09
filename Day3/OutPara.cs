using System;
namespace OutPara
{
    public class MaxFinder
    {
        public static bool TryFindMax(int[] numbers, out int max)
        {
            if (numbers == null || numbers.Length == 0)
            {
                max = default;
                return false;
            }
            max = numbers[0];
            foreach (var n in numbers)
            {
                if (n > max)
                    max = n;
            }
            return true;
        }
    }
}