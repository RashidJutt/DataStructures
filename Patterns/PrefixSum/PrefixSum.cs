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

        public int CountNumberOfNiceSubArrays(int k)
        {
            int subArrayCount = 0;
            var modSumFrequencyMap = new Dictionary<int, int>();
            var sum = 0;
            modSumFrequencyMap[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                var mod = nums[i] % 2;
                sum += mod;
                if (modSumFrequencyMap.ContainsKey(sum - k))
                {
                    subArrayCount += modSumFrequencyMap[sum - k];
                }

                if (!modSumFrequencyMap.ContainsKey(sum))
                {
                    modSumFrequencyMap[sum] = 0;
                }


                modSumFrequencyMap[sum]++;
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

        public int PathSumIII(TreeNode root, int target)
        {
            var map = new Dictionary<int, int>();
            var sum = 0;
            var numberOfPath = 0;
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                root = stack.Pop();
                if (root.Value == null) continue;

                sum += root.Value ?? 0;
                if (map.ContainsKey(sum - target))
                {
                    numberOfPath += map[sum - target];
                }

                if (!map.ContainsKey(sum))
                    map[sum] = 0;
                map[sum]++;

                if (root.Right != null) stack.Push(root.Right);
                if (root.Left != null) stack.Push(root.Left);
            }

            return numberOfPath;
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
            var testArray = new int[] { 1, 2, 3 };
            var prefixSum = new PrefixSum(testArray);
            var subArraysCount = prefixSum.SubArraySumEqualK(3);
            Console.WriteLine(subArraysCount);
        }

        public static void CountNumberOfNiceSubArrays()
        {
            var testArray = new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 };
            var prefixSum = new PrefixSum(testArray);
            var subArraysCount = prefixSum.CountNumberOfNiceSubArrays(2);
            Console.WriteLine(subArraysCount);
        }

        public static void PathSumIIITest()
        {
            TreeNode root = new TreeNode(10);
            root.Left = new TreeNode(5);
            root.Right = new TreeNode(-3);

            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(2);

            root.Right.Left = new TreeNode(null);
            root.Right.Right = new TreeNode(11);

            root.Left.Left.Left = new TreeNode(3);
            root.Left.Left.Right = new TreeNode(-2);

            root.Left.Right.Left = new TreeNode(null);
            root.Left.Right.Right = new TreeNode(1);

            var prefixSum = new PrefixSum(new int[] { });
            var numberOfPath = prefixSum.PathSumIII(root, 8);
            Console.WriteLine(numberOfPath);
        }
    }

    public class TreeNode
    {
        public TreeNode(int? value)
        {
            Value = value;
        }
        public int? Value;
        public TreeNode? Left;
        public TreeNode? Right;
    }
}
