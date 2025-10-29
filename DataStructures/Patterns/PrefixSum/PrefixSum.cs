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

        public int PathSumIII(TreeNode root, int targetSum)
        {
            if (root == null) return 0;
            var map = new Dictionary<long, int>();
            map[0] = 1;
            var numberOfPath = 0;
            var sum = 0;
            DepthFirstSearch(root, sum, map, ref numberOfPath, targetSum);
            return numberOfPath;
        }

        public int[] ProductOfArrayExceptSelf()
        {
            int n = nums.Length;
            int[] result = new int[n];

            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int suffix = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= suffix;
                suffix *= nums[i];
            }

            return result;
        }

        public int LongestSubArraySumEqualToK(int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1;
            var maxLength = 0;
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                {
                    maxLength = Math.Max(maxLength, i - map[sum - k]);
                }
                else
                {
                    map[sum] = i;
                }
            }
            return maxLength;
        }

        public bool ContinuousSubArraySum(int k)
        {
            // ReplaceZeroWithOne(nums);
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1;
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var mod = nums[i] % k;
                sum += mod;
                if (nums[i] == 0)
                {
                    sum += k;
                }
                if (map.ContainsKey(sum % k))
                {
                    if (i - map[sum % k] >= 2)
                        return true;
                }
                else
                {
                    map[sum] = i;
                }
            }
            return false;
        }

        private void ReplaceZeroWithOne(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 1;
                }
            }
        }

        private static void DepthFirstSearch(TreeNode root, long sum, Dictionary<long, int> map, ref int numberOfPath, int targetSum)
        {
            sum += root.val;

            if (map.ContainsKey(sum - targetSum))
            {
                numberOfPath += map[sum - targetSum];
            }

            if (!map.ContainsKey(sum))
                map[sum] = 0;
            map[sum]++;

            if (root.left != null) DepthFirstSearch(root.left, sum, map, ref numberOfPath, targetSum);
            if (root.right != null) DepthFirstSearch(root.right, sum, map, ref numberOfPath, targetSum);

            map[sum]--;
            if (map[sum] == 0)
                map.Remove(sum);
        }
    }

    public class TreeNode
    {
        public TreeNode(int value)
        {
            val = value;
        }
        public int val;
        public TreeNode? left;
        public TreeNode? right;
    }
}
