using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    /// <summary>
    /// A string metric for measuring the difference between two sequences.
    /// Informally, the Levenshtein distance between two words is the minimum number
    /// of single-character edits (i.e. insertions, deletions or substitutions)
    /// required to change one word into the other.
    /// </summary>
    public class LevenshteinDistance : StringMeasureBase
    {
        public LevenshteinDistance(string input1, string input2)
        {
            Input1 = input1;
            Input2 = input2;
            Measure = Calculate(input1, input2);
        }

        public static int Calculate(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            // Step 7
            return d[n, m];
        }
    }
}
