using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tests.LeetCode
{
    class TwoSum
    {
        internal static int[] Find(int[] array, int target)
        {
            var dic = new Dictionary<int, int>();
            for (var k = 0; k < array.Length; k++)
            {
                var diff = target - array[k];

                if (dic.ContainsKey(diff))
                {
                    return new int[] { dic[diff], k };
                }
                else
                {
                    dic[array[k]] = k;
                }
            }

            return new int[0];
        }
    }
}
