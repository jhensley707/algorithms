using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    /// <summary>
    /// Measures the minimum number of substitutions required
    /// to change one string into the other. The Hamming distance
    /// between two strings of equal length is the number of positions
    /// at which the corresponding symbols are different.
    /// </summary>
    public class HammingDistance : StringMeasureBase
    {
        public HammingDistance(string input1, string input2)
        {
            Input1 = input1;
            Input2 = input2;
            Measure = Calculate(input1, input2);
        }

        public static int Calculate(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new InvalidOperationException("Strings must be equal length");
            }

            int distance =
                s1.ToCharArray()
                .Zip(s2.ToCharArray(), (c1, c2) => new { c1, c2 })
                .Count(m => m.c1 != m.c2);

            return distance;
        }
    }
}
