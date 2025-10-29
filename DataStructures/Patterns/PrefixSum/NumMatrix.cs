namespace DataStructures.Patterns.PrefixSum
{
    public class NumMatrix
    {
        int[,] prefixSum;
        public NumMatrix(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) throw new ArgumentNullException("Matrix can not be null or empty");
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            prefixSum = new int[rows + 1, cols + 1];
            BuildPrefixSum(matrix, rows, cols);
        }

        private void BuildPrefixSum(int[][] matrix, int rows, int cols)
        {
            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    prefixSum[r, c] = matrix[r - 1][c - 1] + prefixSum[r - 1, c] + prefixSum[r, c - 1] - prefixSum[r - 1, c - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            row1++; row2++; col1++; col2++;
            return
                  prefixSum[row2, col2]
                - prefixSum[row1 - 1, col2]
                - prefixSum[row2, col1 - 1]
                + prefixSum[row1 - 1, col1 - 1];
        }
    }
}