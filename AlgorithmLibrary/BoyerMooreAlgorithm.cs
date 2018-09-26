using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    /// <summary>
    /// A fast, efficient case-sensitive string search algorithm
    /// </summary>
    public class BoyerMooreAlgorithm
    {
        /// <summary>
        /// Returns the index within this string of the first occurrence of the
        /// specified substring. If it is not a substring, return -1.
        /// </summary>
        /// <param name="haystack">The string to be scanned</param>
        /// <param name="needle">The pattern to find</param>
        /// <returns></returns>
        public static int GetIndex(string haystack, string needle)
        {
            return GetIndex(haystack.ToArray(), needle.ToArray());
        }

        /// <summary>
        /// Returns the index within this string of the first occurrence of the
        /// specified substring. If it is not a substring, return -1.
        /// </summary>
        /// <param name="haystack">The string to be scanned</param>
        /// <param name="needle">The pattern to find</param>
        /// <returns></returns>
        public static int GetIndex(char[] haystack, char[] needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }
            int[] charTable = MakeCharTable(needle);
            int[] offsetTable = MakeOffsetTable(needle);
            // Begin comparing the tail character of the pattern to a
            // character of the target.
            // If it doesn't match, determine if the current target
            // character is a character within the pattern. If it is,
            // shift the index to align the pattern and compare the
            // tail again. If it isn't, shift the length of the
            // entire search pattern since this range of characters
            // don't contain it.
            // If it does match, evaluate each character from the tail
            // looking for an exact match.
            for (int i = needle.Length - 1, j; i < haystack.Length;)
            {
                for (j = needle.Length - 1; needle[j] == haystack[i]; --i, --j)
                {
                    if (j == 0)
                    {
                        return i;
                    }
                }
                // i += needle.length - j; // For naive method
                // Jump to the next position to search, choosing the largest jump
                // value from either the prefix/suffix offset table or the character table
                i += Math.Max(offsetTable[needle.Length - 1 - j], charTable[haystack[i]]);
            }
            return -1;
        }

        /// <summary>
        /// Creates a pre-processing table of character index values
        /// of the search pattern, the needle in the haystack. If a
        /// character is not in the pattern, the default value is the
        /// length of needle. Otherwise, the value is the distance
        /// from the end of the pattern. This will allow a shift to
        /// possibly align the pattern with the exact match.
        /// </summary>
        /// <param name="needle">The pattern to find</param>
        /// <returns>Array of proximity from the tail</returns>
        public static int[] MakeCharTable(string needle)
        {
            return MakeCharTable(needle.ToArray());
        }

        /// <summary>
        /// Creates a pre-processing table of character index values
        /// of the search pattern, the needle in the haystack. If a
        /// character is not in the pattern, the default value is the
        /// length of needle. Otherwise, the value is the distance
        /// from the end of the pattern. This will allow a shift to
        /// possibly align the pattern with the exact match.
        /// </summary>
        /// <param name="needle">The pattern to find</param>
        /// <returns>Array of proximity from the tail</returns>
        private static int[] MakeCharTable(char[] needle)
        {
            const int ALPHABET_SIZE = Char.MaxValue + 1; // 65536
            int[] table = new int[ALPHABET_SIZE];
            // Initialize an int array, each value is the length of the input array
            for (int i = 0; i < table.Length; ++i)
            {
                table[i] = needle.Length;
            }
            // Loop through the input array and create a pointer for each character
            // If a character is duplicated in the pattern, the pointer
            // will be the one closest to the tail so the minimum shift occurs
            for (int i = 0; i < needle.Length - 1; ++i)
            {
                table[needle[i]] = needle.Length - 1 - i;
            }
            return table;
        }

        public static int[] MakeOffsetTable(string needle)
        {
            return MakeOffsetTable(needle.ToArray());
        }

        private static int[] MakeOffsetTable(char[] needle)
        {
            int[] table = new int[needle.Length];
            // Initialize with the entire pattern as a prefix
            int lastPrefixPosition = needle.Length;
            // Perform one pass through the search pattern establishing prefix offsets
            // Starting at the end, determine if each character is a prefix
            for (int i = needle.Length; i > 0; --i)
            {
                if (IsPrefix(needle, i))
                {
                    // The current position is the beginning of a prefix
                    // Set this as the start of the last prefix
                    lastPrefixPosition = i;
                }
                // Update the offset table
                // If there are no prefixes, the offset is twice the length of the pattern less the current index
                table[needle.Length - i] = lastPrefixPosition - i + needle.Length;
            }
            // Perform a second pass through the pattern identifying suffix lengths
            for (int i = 0; i < needle.Length - 1; ++i)
            {
                int slen = SuffixLength(needle, i);
                // Update the offset table
                // If there is no suffix, the initial index eventually becomes the length
                table[slen] = needle.Length - 1 - i + slen;
            }
            return table;
        }

        /// <summary>
        /// Is the substring of needle from index p to the end a prefix of needle?
        /// If p == 0 or p > length of needle, returns true automatically.
        /// </summary>
        /// <param name="needle">The search pattern</param>
        /// <param name="p">Zero-based starting index</param>
        /// <returns></returns>
        public static bool IsPrefix(string needle, int p)
        {
            return IsPrefix(needle.ToArray(), p);
        }

        private static bool IsPrefix(char[] needle, int p)
        {
            // Loop through the search pattern comparing the start
            // with the pointer to find duplicate. This only works
            // if the entire string is mirrored, like HoHo with p = 2.
            // Shouldn't it stop evaluating when j == p?
            for (int i = p, j = 0; i < needle.Length; ++i, ++j)
            {
                if (needle[i] != needle[j])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns the maximum length of the substring which ends at p and is a suffix.
        /// If p equals the length of the search pattern, the suffix length is the
        /// total length of the pattern. If p is greater than the length of the
        /// search pattern, the suffix length is 0.
        /// </summary>
        /// <param name="needle">The search pattern</param>
        /// <param name="p">Zero-based starting index</param>
        /// <returns>Length of the suffix if pattern duplication occurs</returns>
        public static int SuffixLength(string needle, int p)
        {
            return SuffixLength(needle.ToArray(), p);
        }

        private static int SuffixLength(char[] needle, int p)
        {
            if (p == needle.Length - 1) { return needle.Length; }
            if (p > needle.Length - 1) { return 0; }
            // A suffix is a duplicate pattern of characters within
            // the search pattern, located at the end of the pattern.
            int len = 0;
            // Work backwards comparing the character at the pointer p
            // with the last character of the pattern. If the characters
            // match, increment the length of the suffix.
            for (int i = p, j = needle.Length - 1;
                     i >= 0 && needle[i] == needle[j]; --i, --j)
            {
                len += 1;
            }
            return len;
        }
    }
}
