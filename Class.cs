using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Solution
    {
        public int[] AnagramMappings(int[] A, int[] B)
        {
            if (A == null || B == null || A.Length != B.Length)
                return null;

            Dictionary<int, int> BValues = new Dictionary<int, int>();

            for (int i = 0; i < A.Length; i++)
                AddOrUpdate(BValues, B[i], i);

            int[] anagramMapping = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
                anagramMapping[i] = BValues[A[i]];

            return anagramMapping;
        }

        private void AddOrUpdate(Dictionary<int, int> dictionary, int key, int val)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = val;
            else
                dictionary.Add(key, val);
        }
    }
}