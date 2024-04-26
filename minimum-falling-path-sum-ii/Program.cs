using System;

class FallingPathSum
{
    public static int MinFallingPathSum(int[][] grid)
    {
        int n = grid.Length;

        // Initialize dp with the grid values (can use grid directly)
        int[][] dp = grid;

        // Iterate through each row starting from the second row
        for (int row = 1; row < n; row++)
        {
            // Find the two smallest values in the previous row
            int min1 = int.MaxValue, min2 = int.MaxValue;
            int min1Index = -1;
            
            for (int col = 0; col < n; col++)
            {
                if (dp[row - 1][col] < min1)
                {
                    min2 = min1;
                    min1 = dp[row - 1][col];
                    min1Index = col;
                }
                else if (dp[row - 1][col] < min2)
                {
                    min2 = dp[row - 1][col];
                }
            }

            // Calculate the minimum sum for each cell in the current row
            for (int col = 0; col < n; col++)
            {
                // Choose the minimum sum from the previous row based on non-zero shifts
                if (col == min1Index)
                {
                    dp[row][col] += min2;
                }
                else
                {
                    dp[row][col] += min1;
                }
            }
        }

        // Find the minimum sum in the last row
        int result = int.MaxValue;
        for (int col = 0; col < n; col++)
        {
            result = Math.Min(result, dp[n - 1][col]);
        }

        return result;
    }

    public static void Main()
    {
        // Test the function with an example input
        int[][] grid = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        int result = MinFallingPathSum(grid);
        Console.WriteLine($"The minimum sum of a falling path with non-zero shifts is: {result}");
    }
}
