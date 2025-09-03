namespace DataStructure.Patterns
{
    public class ContiguousArray
    {
        public static int FindMaxLength(int[] nums)
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

    public class ContiguousArrayTest
    {
        public static void ContiguousArrayTestMethod()
        {
            int[] testArray = new int[] { 0, 1 };
            var maxLength = ContiguousArray.FindMaxLength(testArray);


            testArray = new int[] { 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1 };
            var length = testArray.Length;
            maxLength = ContiguousArray.FindMaxLength(testArray);
            Console.WriteLine(maxLength);
        }
    }
}
