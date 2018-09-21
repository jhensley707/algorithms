using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    /// <summary>
    /// A string metric measuring an edit distance between two sequences.
    /// The Jaro distance between two words is the minimum number of single-character
    /// transpositions required to change one word into the other. The Winkler
    /// variant uses a prefix scale p which gives more favourable ratings to strings
    /// that match from the beginning for a set prefix length ℓ. 
    /// </summary>
    public class JaroWinklerDistance : StringProximityBase
    {
        /* The Winkler modification will not be applied unless the 
         * percent match was at or above the weightThreshold percent 
         * without the modification. 
         * Winkler's paper used a default value of 0.7
         */
        /// <summary>
        /// The minimum percent match required to apply the Winkler modification
        /// </summary>
        public double WeightThreshold { get; }

        /* Size of the prefix to be considered by the Winkler modification. 
         * Winkler's paper used a default value of 4
         */
        /// <summary>
        /// Number of the leading characters to evaluate for the prefix scale
        /// </summary>
        public int PrefixLength { get; }

        public JaroWinklerDistance(string input1, string input2, double weightThreshold = 0.7, int prefixLength = 4)
        {
            WeightThreshold = weightThreshold;
            PrefixLength = prefixLength;
            Input1 = input1;
            Input2 = input2;
            Proximity = CalculateProximity(input1, input2);
            Measure = 1.0 - Proximity;
        }

        /// <summary>
        /// Returns the Jaro-Winkler distance between the specified  
        /// strings. The distance is symmetric and will fall in the 
        /// range 0 (perfect match) to 1 (no match). 
        /// </summary>
        /// <param name="s1">First String</param>
        /// <param name="s2">Second String</param>
        /// <returns></returns>
        public static double CalculateDistance(string s1, string s2, double weightThreshold = 0.7, int prefixLength = 4)
        {
            return 1.0 - CalculateProximity(s1, s2, weightThreshold, prefixLength);
        }

        /// <summary>
        /// Returns the Jaro-Winkler distance between the specified  
        /// strings. The distance is symmetric and will fall in the 
        /// range 0 (no match) to 1 (perfect match). 
        /// </summary>
        /// <param name="s1">First String</param>
        /// <param name="s2">Second String</param>
        /// <returns></returns>
        public static double CalculateProximity(string s1, string s2, double weightThreshold = 0.7, int prefixLength = 4)
        {
            int length1 = s1.Length;
            int length2 = s2.Length;
            if (length1 == 0)
            {
                return length2 == 0 ? 1.0 : 0.0;
            }

            int searchRange = Math.Max(0, Math.Max(length1, length2) / 2 - 1);

            // default initialized to false
            bool[] isMatched1 = new bool[length1];
            bool[] isMatched2 = new bool[length2];

            int numCommon = 0;
            for (int i = 0; i < length1; ++i)
            {
                int lStart = Math.Max(0, i - searchRange);
                int lEnd = Math.Min(i + searchRange + 1, length2);
                for (int j = lStart; j < lEnd; ++j)
                {
                    if (isMatched2[j]) continue;
                    if (s1[i] != s2[j])
                        continue;
                    isMatched1[i] = true;
                    isMatched2[j] = true;
                    ++numCommon;
                    break;
                }
            }

            if (numCommon == 0) { return 0.0; }

            int numHalfTransposed = 0;
            int k = 0;
            for (int i = 0; i < length1; ++i)
            {
                if (!isMatched1[i]) continue;
                while (!isMatched2[k]) ++k;
                if (s1[i] != s2[k])
                    ++numHalfTransposed;
                ++k;
            }
            // System.Diagnostics.Debug.WriteLine("numHalfTransposed=" + numHalfTransposed);
            int lNumTransposed = numHalfTransposed / 2;

            // System.Diagnostics.Debug.WriteLine("numCommon=" + numCommon + " numTransposed=" + numTransposed);
            double numCommonD = numCommon;
            double weight = (numCommonD / length1
                             + numCommonD / length2
                             + (numCommon - lNumTransposed) / numCommonD) / 3.0;

            if (weight <= weightThreshold) { return weight; }
            int max = Math.Min(prefixLength, Math.Min(s1.Length, s2.Length));
            int pos = 0;
            while (pos < max && s1[pos] == s2[pos])
            {
                ++pos;
            }
            if (pos == 0) { return weight; }
            return weight + 0.1 * pos * (1.0 - weight);
        }
    }
}
