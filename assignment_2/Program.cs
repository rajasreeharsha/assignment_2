using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/


namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Checking  the array if it is empty
                if (nums.Length==0)
                    return 0;
                
                int cnt = 1; // declaring a local variable in order to access the index of the array nums
                for (int i = 1;i<nums.Length;i++)
                {
                    // declaring a condition in order check previous number is same as the number
                    if(nums[i]!=nums[i-1]) 
                    {
                        // saving the number inorder to get unique numbers
                        nums[cnt] = nums[i];
                        cnt++; // increasing the cnt value in order to access other elements in array
                    }
                }

                return cnt;
            
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning :
         Above code is used to get unique numbers from a array. Firstly the compared adjacent elements inorder to get unique values
        and then using cnt to get count of unique values. And then the array is saved with the unique values.
         */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int idx = 0; // declaring a local variable to access the index of array nums

                for(int i = 0;i<nums.Length;i++)
                {
                    if(nums[i]!=0) // checking whether the current element is 0 
                    {
                        nums[idx] = nums[i]; // saving non 0 element 
                        idx++;// increasing the index to access other elements 
                    }
                }

                for(int i = idx;i<nums.Length;i++)
                {
                    nums[i] = 0; // saving all other elements which are 0 
                }
                return new List<int>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning:
        
           The code rearranges elements in an array by moving non-zero elements to the beginning 
        while placing zeros at the end. It uses a loop to iterate through the array, checks for non-zero elements, 
        and maintains their original order. A counter (idx) keeps track of the index for placing non-zero elements. 
        After moving non-zero elements, it fills the remaining elements with zeros. 
        The method includes exception handling (try-catch) and should return the modified array instead of an empty list.
         */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                Array.Sort(nums); // sorting the array

                IList<IList<int>> result = new List<IList<int>>();

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // skipping duplicates to avoid duplicate triplets
                        continue;

                    int t = -nums[i]; 
                    int l = i + 1; // index for second element
                    int r = nums.Length - 1; // index for third element

                    while (l < r)
                    {
                        int sum = nums[l] + nums[r];

                        if (sum == t)
                        {
                            result.Add(new List<int> { nums[i], nums[l], nums[r] });


                            while (l < r && nums[l] == nums[l + 1]) // skipping duplicates inorder to avoid duplicate triplets
                                l++;
                            while (l < r && nums[r] == nums[r - 1])
                                r--;

                            l++;
                            r--;
                        }
                        else if (sum < t)
                        {
                            l++;
                        }
                        else
                        {
                            r--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         self learning:
         The code uses array sorting to facilitate triplet search and skips duplicates to prevent repeated triplets. 
        It employs a two-pointer approach (l and r) to find triplets summing to a target value (t). 
        Unique triplets satisfying the sum condition are added to the result list (result). 
         */
        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int mcnt = 0; // local variable for max count
                int ccnt = 0; // local variable for current count

                foreach (int n in nums)
                {
                    if (n == 1) // condition for checking whether the element is 1
                    {
                        ccnt++; // increasing current count
                        mcnt = Math.Max(mcnt, ccnt); // saving max number in max count
                    }
                    else // if element is not 1 saving current count as 0
                    {
                        ccnt = 0; 
                    }
                }

                return mcnt; // returning the count
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning:
        
          The code efficiently determines the maximum consecutive ones in an array using local variables for current 
        and maximum counts. It iterates through the array, incrementing the current count for each 1 encountered and 
        updating the maximum count accordingly. When encountering a non-1 element, it resets the current count

         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int dcmlnum = 0;
                int b_value = 1;

                while (binary != 0)
                {
                    int last_digit = binary % 10; //accessing the last element of the input binary number
                    binary /= 10; 
                    dcmlnum += last_digit * b_value; // saving the number in variable
                    b_value *= 2; // multiplying the value with 2 for the next iteration
                }

                return dcmlnum;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning:
        
       The code efficiently converts a binary number to decimal using iterative processing and 
        positional value calculations. It accesses each digit of the binary number, updates the binary value for the next iteration, 
        and accumulates the decimal result. 
        The process involves multiplying each binary digit by its positional value (powers of 2) for accurate decimal conversion
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2) // checking if the array nums has the less than 2 elements
                    return 0;

                // declaring variables for getting max and min values
                int min_num = int.MaxValue;
                int max_num = int.MinValue;
                foreach (int n in nums)
                {
                    min_num = Math.Min(min_num, n);
                    max_num = Math.Max(max_num, n);
                }

                // getting bucket size based on array's size 
                int b_size = Math.Max(1, (max_num - min_num) / (nums.Length - 1));

                // getting the no of buckets required
                int num_buckets = (max_num - min_num) / b_size + 1;

                // declaring arrays to store minimum and maximum numbers in each bucket
                int[] min_bucket = new int[num_buckets];
                int[] max_bucket = new int[num_buckets];
                for (int i = 0; i < num_buckets; i++)
                {
                    min_bucket[i] = int.MaxValue;
                    max_bucket[i] = int.MinValue;
                }

                foreach (int n in nums)
                {
                    int idx = (n - min_num) / b_size;
                    min_bucket[idx] = Math.Min(min_bucket[idx], n); //getting minimum number in bucket
                    max_bucket[idx] = Math.Max(max_bucket[idx], n); //getting maximum number in bucket
                }

                int max_gap = 0; //getting max gap between numbers
                int p_max = min_num;
                for (int i = 0; i < num_buckets; i++)
                {
                    if (min_bucket[i] == int.MaxValue) // Skip empty buckets
                        continue;
                    max_gap = Math.Max(max_gap, min_bucket[i] - p_max);
                    p_max = max_bucket[i];
                }

                return max_gap;
            }

            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning:
        
         The code efficiently calculates the maximum gap between numbers 
        in an array by optimizing bucketing and min-max calculations. 
        It checks the array size to handle edge cases, computes bucket size based on the array's range, 
        and uses buckets to group numbers for gap calculation. 
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {

                Array.Sort(nums, (num1, num2) => num2.CompareTo(num1)); //sorting the array
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (nums[i] < nums[i + 1] + nums[i + 2]) //checking whether the elements in the array can form a traingle
                    {
                        return nums[i] + nums[i + 1] + nums[i + 2]; //returning largest perimeter that can be formed
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         
       The code efficiently finds the largest perimeter that can be formed by elements in a sorted array by checking triplet combinations. 
        It utilizes sorting for optimization and checks if elements satisfy the triangle inequality theorem. 
        Returns the largest perimeter among valid triangles or 0 if no valid triangle can be formed. 
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                int idx;//declaring the index for accessing every element in the string

                while ((idx = s.IndexOf(part)) != -1) //looping until the substring is no more in the main string
                {
                    s = s.Remove(idx, part.Length);//removing the substring from the main string
                }
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self learning:
        The code efficiently removes all occurrences of a specified substring (part) from a given string (s) 
        using a while loop and string manipulation methods (IndexOf and Remove). 
        It continues removing occurrences until none are left, handling cases where the substring is not present.
         */

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
