using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Solution
    {
        public int[] AnagramMappings(int[] nums1, int[] nums2)
        {

            if (nums1 == null || nums2 == null || nums1.Length != nums2.Length)
                return null;

            Dictionary<int, int> BValues = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
                AddOrUpdate(BValues, nums2[i], i);

            int[] ans = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
                ans[i] = BValues[nums1[i]];

            return ans;
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