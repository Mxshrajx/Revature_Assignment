using System;
namespace IsPalindrome1
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            var removespace = s.Replace(" ", "").ToLower();
            int left = 0;
            int right = removespace.Length - 1;

            while (left < right)
            {
                if (removespace[left] != removespace[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}