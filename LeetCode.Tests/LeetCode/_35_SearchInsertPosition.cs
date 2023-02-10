using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tests.LeetCode
{
    internal class _35_SearchInsertPosition
    {
        /*
        Given a sorted array of distinct integers and a target value, return 
        the index if the target is found.If not, return the index where it would be 
        if it were inserted in order.

        You must write an algorithm with O(log n) runtime complexity.

        */

        public int SearchInsert(int[] nums, int target)
        {
            for (var k = 0; k < nums.Length; k++)
            {
                if (nums[k] >= target)
                    return k;
            }

            return nums.Length;

            /* Better solution - NOT MINE
             * 
        int min = 0;
        int max = nums.Length - 1;
        while(min <= max){
            int mid = (min + max) / 2;
            if (target == nums[mid]) return mid;

            if (target < nums[mid]){
                max = mid - 1;
            }
            else {
                min = mid + 1;
            }
        }

        return min;

            */
        }
    }
}
