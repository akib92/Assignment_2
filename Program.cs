using System;
using System.Collections.Generic;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:

            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = (List<string>)CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are same");
            else
                Console.WriteLine("Number of Occurences of each element are not same");

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "lenovo" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "color";
            string ruleValue = "silver";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);

            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "ab";
            string[] words = { "ad", "bd", "aaab", "baa", "badab" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = MinSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
        }


        /*
        Question 1:
        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                // Initialize the Max gain from 1st point
                int max = gain[0] > 0 ? gain[0] : 0;
                int pt = gain[0];

                // Iterate thru remaining points to find the max value
                for (int i = 1; i < gain.Length; i++)
                {
                    pt = gain[i] + pt;
                    Console.WriteLine("Pt : " + pt);
                    if (pt > max)
                        max = pt;
                }
                // Return max value
                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Learned about how to find max value of an element in an array

        /*
        
        Question 2:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //inintialize the counter
                int i = 0, j = nums.Length - 1;
                // Perform Binary search
                while (i <= j)
                {
                    int mid = i + (j - i) / 2;
                    if (target == nums[mid])
                    {
                        return mid;
                    }
                    else if (target > nums[mid])
                    {
                        i = mid + 1;
                    }
                    else
                    { j = mid - 1; }
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Learned how to match a value with existing value in an array

        /*
         
        Question 3
       
        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]
        
        */

        public static IList<string> CommonChars(string[] words)

        {
            try
            {
                int[] ansMap = new int[26], charMap = new int[26];
                // Initialize the Max count from 1st string
                foreach (var ch in words[0])
                    ansMap[ch - 'a']++;

                // Iterate thru remaining strings
                for (int i = 1; i < words.Length; i++)
                {
                    // Create the charCount for each string
                    foreach (var ch in words[i])
                        charMap[ch - 'a']++;
                    // Now update each index of ansMap with minimum of (ansMap[i],charMap[i])
                    for (int j = 0; j < ansMap.Length; j++)
                    {
                        ansMap[j] = Math.Min(ansMap[j], charMap[j]);
                        charMap[j] = 0;       // resetting for next iteration
                    }
                }

                IList<string> commonwords = new List<string>();
                for (int i = 0; i < ansMap.Length; i++)
                    while (ansMap[i]-- > 0)
                        commonwords.Add("" + (char)(i + 'a'));
                return commonwords;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Learned how to compare strings in an array

        /*
        Question 4:
        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.
        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
        Example 2:
        Input: arr = [1,2]
        Output: false
       
         */

        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                var countDictionary = new Dictionary<int, int>();

                // Create a count dictionary
                foreach (var item in arr)
                {
                    countDictionary[item] = (!(countDictionary.ContainsKey(item))) ? 1 : countDictionary[item] + 1;
                }

                // Create Set of the values and return false when collision occurs 
                var valSet = new HashSet<int>();
                foreach (var item in countDictionary.Keys)
                {
                    if (valSet.Contains(countDictionary[item]))
                    {
                        return false;
                    }
                    valSet.Add(countDictionary[item]);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Learned how to find/sort repition of a character in an array

        /*
        
        Question 5:
        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        ?	ruleKey == "type" and ruleValue == type.
        ?	ruleKey == "color" and ruleValue == color.
        ?	ruleKey == "name" and ruleValue == name.
        Return the number of items that match the given rule.
        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].
        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 
        Note that the item ["computer","silver","phone"] does not match.
        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            try
            {
                // Initialize a value
                int match = 0;
                // Iterate thru the items in the array list and match value using ruleKey
                foreach (var list in items)
                {
                    for (int i = 0; i < list.Count; i += 3)
                    {
                        if (ruleKey == "type" && list[i] == ruleValue)
                        {
                            match++;
                        }
                        else if (ruleKey == "color" && list[i + 1] == ruleValue)
                        {
                            match++;
                        }
                        else if (ruleKey == "name" && list[i + 2] == ruleValue)
                        {
                            match++;
                        }
                    }
                }
                // return match number if match item and value
                return match;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //matching elements in an array using datatype

        /*
        
        Question 6:
        
        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.
        Note: Solve it in O(n) and O(1) space complexity.
        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it?s useful to use pointers tracking the two ends of the array.
        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]
        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]
        */

        public static void targetSum(int[] nums, int target)
        {
            try
            {
                int l = 0, r = nums.Length - 1, sum;
                while (true)
                {
                    // Iterate thru the items in the array and calculate sum.
                    sum = nums[l] + nums[r];
                    // See if sum is equal to target
                    if (sum == target)
                        break;
                    else if (sum < target)
                        l += 1;
                    else
                        r -= 1;
                }
                // return the two values
               Console.WriteLine(l + 1+" "+r + 1 );

            }
            catch (Exception)
            {

                throw;
            }
        }

        //how to summ elements in an existing array to find a target sum

        /*
         
        Question 7:
        You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if every character in words[i] appears in the string allowed.
        Return the number of consistent strings in the array words.
        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 
        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string ?bd? is not consistent since ?d? is not in string allowed.
        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.
        */

        public static int CountConsistentStrings(string allowed, string[] words)
        {
            try
            // Time O(n*l) || Space O(1), n = len of 'words' arr & l = avg length of each word
            {
                bool[] charSet = new bool[26];
                for (int i = 0; i < allowed.Length; i++)
                    charSet[allowed[i] - 'a'] = true;

                int count = 0;
                for (int i = 0; i < words.Length; i++)
                    if (Consistent(words[i]))
                        count++;
                return count;
                // local func
                bool Consistent(string w)
                {
                    foreach (var ch in w)
                        if (!charSet[ch - 'a'])
                            return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //how to sort string in an array based on their characters

        /*
        Question 8:
        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.
        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.
 
        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.
        */

        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                //Converting the array into Dictionary and looks for matches 

                if (nums1 == null || nums2 == null || nums1.Length != nums2.Length)
                    return null;

                Dictionary<int, int> BValues = new Dictionary<int, int>();

                //Iterate through the value and get the index number
                for (int i = 0; i < nums1.Length; i++)
                    AddOrUpdate(BValues, nums2[i], i);

                int[] ans = new int[nums1.Length];

                for (int i = 0; i < nums1.Length; i++)
                    ans[i] = BValues[nums1[i]];
                //Return index number
                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void AddOrUpdate(Dictionary<int, int> dictionary, int key, int val)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = val;
            else
                dictionary.Add(key, val);
        }

        // mapping two similar arrays with their elements

        /*
        
        Question 9:
        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1
        */

        public static int MaximumSum(int[] arr)
        {
            try
            {
                int sum = 0;
                int maxSum = int.MinValue;
                //Iterate through the value in the array and calculate max sum
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                    maxSum = Math.Max(sum, maxSum);
                    if (sum < 0) sum = 0;
                }

                return maxSum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Add elements in the array to get the max sum by using each elements once

        /*
         
        Question 10:
        Given an array of positive integers nums and a positive integer target, return the minimal length of a contiguous subarray [nums[l], nums[l+1], ..., nums[r-1], nums[r]] of which the sum is greater than or equal to target. If there is no such subarray, return 0 instead.
        Note: Try to solve it in O(n) time.
        Hint: Try to create a window and track the sum you have in the window.
        Example 1:
        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.
        Example 2:
        Input: target = 4, nums = [1,4,4]
        Output: 1
        */

        public static int MinSubArrayLen(int target_subarray_sum, int[] arr10)
        {
            try
            {
                int start = 0, sum = 0, minWin = int.MaxValue;
                // Iterate through the array 
                for (int end = 0; end < arr10.Length; end++)
                {
                    // sum the elements in the array to look for the target sum by taking minimum elements
                    sum += arr10[end];
                    if (sum >= target_subarray_sum)
                    {
                        while (sum - arr10[start] >= target_subarray_sum)
                            sum -= arr10[start++];
                        minWin = Math.Min(minWin, end - start + 1);
                    }
                }
                return minWin != int.MaxValue ? minWin : 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

// Find the target sum by using the least possible combination in an array
