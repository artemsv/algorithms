namespace LeetCode.Tests.LeetCode
{
    internal class RemoveElementSolution
    {
        public int RemoveElement(int[] nums, int val)
        {
            var index = 0;
            var x = 0;

            while (index < nums.Length)
            {
                if (nums[index] == val)
                {
                    x = index + 1;
                    if (x >= nums.Length)
                    {
                        // last element
                        return index;
                    }
                    else
                    {
                        while (nums[x] == val)
                        {
                            x++;
                            if (x >= nums.Length)
                                return index;
                        }
                        nums[index] = nums[x];
                        nums[x] = val;
                        index++;
                    }
                }
                else
                {
                    index++;
                }
            }

            return index;
        }
    }
}
