Given a 2D grid consists of 0s (land) and 1s (water).  An island is a maximal 4-directionally connected group of 0s and a closed island is an island totally (all left, top, right, bottom) surrounded by 1s.

Return the number of closed islands.

 

Example 1:



Input: grid = [[1,1,1,1,1,1,1,0],[1,0,0,0,0,1,1,0],[1,0,1,0,1,1,1,0],[1,0,0,0,0,1,0,1],[1,1,1,1,1,1,1,0]]
Output: 2
Explanation: 
Islands in gray are closed because they are completely surrounded by water (group of 1s).
Example 2:



Input: grid = [[0,0,1,0,0],[0,1,0,1,0],[0,1,1,1,0]]
Output: 1
Example 3:

Input: grid = [[1,1,1,1,1,1,1],
               [1,0,0,0,0,0,1],
               [1,0,1,1,1,0,1],
               [1,0,1,0,1,0,1],
               [1,0,1,1,1,0,1],
               [1,0,0,0,0,0,1],
               [1,1,1,1,1,1,1]]
Output: 2
 

Constraints:

1 <= grid.length, grid[0].length <= 100
0 <= grid[i][j] <=1

public class Solution {
    int[][] grid;
    int numRows, numCols;

    private void Setup(int[][] grid) {
        this.grid = grid;
        numRows = grid.Length;
        numCols = grid[0].Length;
    }

    public int ClosedIsland(int[][] grid) {
        Setup(grid);
        int count = 0;
        for (int row = 0; row < numRows; row++) {
            for (int col = 0; col < numCols; col++) {
                if (grid[row][col] == 0 && IsClosed(row, col)) {
                    count++;
                }
            }
        }

        return count;
    }

    private int[] dirx = {0, 1, 0, -1};
    private int[] diry = {-1, 0, 1, 0};

    private bool OutOfBounds(int row, int col) {
        return row < 0 || row >= numRows || col < 0 || col >= numCols;
    }

    public bool IsClosed(int row, int col) {
        if (OutOfBounds(row, col)) {
            return false;
        }

        if (grid[row][col] == 1) {
            return true;
        }
        if (grid[row][col] == -1) {
            return false;
        }

        grid[row][col] = 1;
        for (int i = 0; i < 4; i++) {
            if (!IsClosed(row + dirx[i], col + diry[i])) {
                grid[row][col] = -1;
                return false;
            }
        }

        return true;
    }
}
