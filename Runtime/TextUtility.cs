using System;
using System.Linq;
using UnityEngine;

namespace JauntyBear.UnityText
{
    public static class TextUtility
    {
        /// <summary>
        /// check whether a string exists in an array of strings.
        /// </summary>
        /// <param name="textAsset">a Unity TextAsset.</param>
        /// <returns>string entry found or not.</returns>
        public static string[] TextAssetToArray(TextAsset textAsset)
        {
            return textAsset
                ? textAsset.text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                : null;
        }

        /// <summary>
        /// check whether a string exists in an array of strings.
        /// </summary>
        /// <param name="sortedEntries">sorted array of strings.</param>
        /// <param name="entry">string to search.</param>
        /// <returns>string entry found or not.</returns>
        public static bool IsStringInSortedArray(string[] sortedEntries, string entry)
        {
            int index = Array.BinarySearch(sortedEntries, entry);

            if (index < 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// check whether a prefix exists in an array of strings.
        /// </summary>
        /// <param name="sortedEntries">sorted array of strings.</param>
        /// <param name="prefix">prefix to search.</param>
        /// <returns>prefix found or not.</returns>
        public static bool IsPrefixInSortedArray(string[] sortedEntries, string prefix)
        {
            int index = Array.BinarySearch(sortedEntries, prefix);

            // If the returned index is negative, the word wasn't found.
            // The index is the one's compliment of the the place where it would be in the list.
            if (index < 0)
            {
                index = ~index;
            }
            else
                return true; // perfect match

            for (int i = index; i < sortedEntries.Length && sortedEntries[i].StartsWith(prefix); i++)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// concatenate arrays.
        /// </summary>
        /// <param name="params">list of arrays</param>
        /// <returns>concatenated arrays.</returns>
        public static T[] ConcatArrays<T>(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            int offset = 0;
            for (int x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }

        /// <summary>
        /// get random lowercase alpha char.
        /// </summary>
        /// <returns>any lowercase alpha character.</returns>
        public static char GetRandomLowerAlphaChar()
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
            // random lowercase letter
            int a = random.Next(0, 26);
            char ch = (char)('a' + a);
            return ch;
        }
    }
}