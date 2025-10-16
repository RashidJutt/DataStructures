namespace DataStructures.Patterns.PrefixSum
{
    public class NumMatrix
    {
        Dictionary<int, Dictionary<int, int>> prefixSum = new Dictionary<int, Dictionary<int, int>>();
        public NumMatrix(int[][] matrix)
        {

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrix[rowIndex].Length; columnIndex++)
                {
                    if (rowIndex == 0 && columnIndex == 0)
                    {
                        prefixSum[rowIndex] = new Dictionary<int, int>();
                        prefixSum[rowIndex][columnIndex] = matrix[rowIndex][columnIndex];
                        continue;
                    }

                    var top = 0;
                    if (prefixSum.ContainsKey(rowIndex - 1) && prefixSum[rowIndex - 1].ContainsKey(columnIndex))
                    {
                        top = prefixSum[rowIndex - 1][columnIndex];
                    }
                    var left = 0;
                    if (prefixSum.ContainsKey(rowIndex) && prefixSum[rowIndex].ContainsKey(columnIndex - 1))
                    {
                        left = prefixSum[rowIndex][columnIndex - 1];
                    }

                    var diagnal = 0;
                    if (prefixSum.ContainsKey(rowIndex - 1) && prefixSum[rowIndex - 1].ContainsKey(columnIndex - 1))
                    {
                        diagnal = prefixSum[rowIndex - 1][columnIndex - 1];
                    }

                    if (!prefixSum.ContainsKey(rowIndex))
                    {
                        prefixSum[rowIndex] = new Dictionary<int, int>();
                    }

                    prefixSum[rowIndex][columnIndex] = matrix[rowIndex][columnIndex] + left + top - diagnal;
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var prefixSumX2Y2 = 0;
            if (prefixSum.ContainsKey(row2) && prefixSum[row2].ContainsKey(col2))
            {
                prefixSumX2Y2 = prefixSum[row2][col2];
            }

            var prefixSumX1Min1Y2 = 0;
            if (prefixSum.ContainsKey(row1 - 1) && prefixSum[row1 - 1].ContainsKey(col2))
            {
                prefixSumX1Min1Y2 += prefixSum[row1 - 1][col2];
            }

            var prefixSumY1Min1X2 = 0;

            if (prefixSum.ContainsKey(row2) && prefixSum[row2].ContainsKey(col1 - 1))
            {
                prefixSumY1Min1X2 = prefixSum[row2][col1 - 1];
            }

            var prefixSumY1Min1X1Min1 = 0;
            if (prefixSum.ContainsKey(row1 - 1) && prefixSum[row1 - 1].ContainsKey(col1 - 1))
            {
                prefixSumY1Min1X1Min1 = prefixSum[row1 - 1][col1 - 1];
            }

            var sumRange = prefixSumX2Y2 - prefixSumX1Min1Y2 - prefixSumY1Min1X2 + prefixSumY1Min1X1Min1;

            return sumRange;
        }
    }
}