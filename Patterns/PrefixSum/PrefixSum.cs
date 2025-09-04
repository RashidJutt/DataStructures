namespace DataStructures.Patterns.PrefixSum
{
    public class PrefixSum
    {
        private int[] nums;

        public PrefixSum(int[] nums)
        {
            this.nums = nums;
        }

        public int SumRange(int left, int right)
        {
            var sum = 0;
            for (var i = left; i <= right; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        public int FindMaxLength()
        {
            nums = ReplaceZeroWithMinusOne(nums);
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1;
            var maxLength = 0;
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum))
                {
                    maxLength = Math.Max(maxLength, i - map[sum]);
                }
                else
                {
                    map[sum] = i;
                }
            }
            return maxLength;
        }

        public int SubArraySumEqualK(int k)
        {
            var map = new Dictionary<int, int>();
            map[0] = 1;

            int sum = 0;
            int subArrayCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (map.ContainsKey(sum - k))
                {
                    subArrayCount += map[sum - k];
                }

                if (!map.ContainsKey(sum))
                    map[sum] = 0;

                map[sum]++;
            }

            return subArrayCount;
        }

        private static int[] ReplaceZeroWithMinusOne(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = -1;
                }
            }
            return nums;
        }
    }

    public static class PrefixSumTest
    {
        public static void SumRageTest()
        {
            var testArray = new int[] { -2, 0, 3, -5, 2, -1 };
            var prefixSum = new PrefixSum(testArray);
            Console.WriteLine(prefixSum.SumRange(0, 2));
            Console.WriteLine(prefixSum.SumRange(2, 5));
            Console.WriteLine(prefixSum.SumRange(0, 5));

        }

        public static void ContiguousArrayLengthTest()
        {
            var testArray = new int[] { 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1 };
            var prefixSum = new PrefixSum(testArray);
            var maxLength = prefixSum.FindMaxLength();
            Console.WriteLine(maxLength);
        }

        public static void SubArraySumEqualKTest()
        {
            var testArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var prefixSum = new PrefixSum(testArray);
            var subArraysCount = prefixSum.SubArraySumEqualK(0);
            Console.WriteLine(subArraysCount);
        }
    }
}
