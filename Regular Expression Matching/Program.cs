using System;
using System.Collections.Generic;
using System.Linq;

namespace Regular_Expression_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsMatch("aa", "a"));
            //Console.WriteLine(IsMatch("aaaaaaaaa", "a*"));
            //Console.WriteLine(IsMatch("aaaaaaaaabb", "a*b*"));
            //Console.WriteLine(IsMatch("aaaaaaaaa", ".*"));
            //Console.WriteLine(IsMatch("aab", "c*a*b"));
            //Console.WriteLine(IsMatch("mississippi", "mis*is*ip*."));
            //Console.WriteLine(IsMatch("abbbbbbbb", ".*c"));
            //Console.WriteLine(IsMatch("aab", "c*a*b"));
            Console.WriteLine(IsMatch("aaa", "a*a"));
        }

        static bool IsMatch(string s, string p)
        {
            int[] indicesOfStar = Enumerable.Range(0, p.Length).Where(i => p[i] == '*').Select(x => x - 1).ToArray();
            int i, j;
            for (i = 0, j = 0; i < s.Length; i++)
            {
                if (j >= p.Length) return false;
                if (indicesOfStar.Length == 0)
                {
                    if (p[j] == '.')
                    {
                        j++;
                        continue;
                    }
                    if (s[i] != p[j++]) return false;
                }
                else
                {
                    int starIndex = Array.FindIndex(indicesOfStar, (e) => e == j);
                    if (starIndex == -1)
                    {
                        if (s[i] != p[j++] && p[j - 1] != '.')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        starIndex = indicesOfStar[starIndex];
                        if (s[i] != p[starIndex] && p[starIndex] != '.')
                        {
                            j += 2;
                            continue;
                        }
                        while (i < s.Length && (s[i] == p[starIndex] || p[starIndex] == '.'))
                        {
                            i++;
                        }
                        i--;
                        j += 2;
                    }
                }
            }
            if (j < p.Length || (indicesOfStar.Length > 0 && s[s.Length - 1] != p[indicesOfStar[indicesOfStar.Length - 1]])) return false;
            return true;
        }
    }
}
