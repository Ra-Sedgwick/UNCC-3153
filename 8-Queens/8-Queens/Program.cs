using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[,] board = BuildBoard(8, 8);
            PrintGrid(board);
        }

        public static int[,] BuildBoard(int row, int col)
        {
            int[,] board = new int[row, col];
            Random rand = new Random();


            // Initialzie board with all 0's.
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    board[i, j] = 0;

            // Place One queen randomly in each column.
            for (int i = 0; i < col; i++)
            {
                int queen = rand.Next(0, col);
                Console.WriteLine(queen);
                board[queen, i] = 1;
            }

            return board;
        }


        public static List<int[]> GetQueens(int[,] grid)
        {
            List<int[]> Queens = new List<int[]>();


            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == 1)
                    {
                        int[] queen = [r, c];
                        Queens.Add(queen);
                    }
                }
            }

            return Queens;

        }


        // No queen occupies same Row, Col, Diag
        public static bool CheckGoalState(int[,] grid, List<int[,]> Queens)
        {
            // To check if two queens are on the same diagonal check
            // the difference between the rows and columns fo the two queens.
            // if they are they same they are on the same diagonal. 

            // Check Row

            // Check Col

            // Check Diag

            return true;
        }

        public static void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    Console.Write(grid[i, j] + " ");

                Console.WriteLine();
            }
        }
    }
}


