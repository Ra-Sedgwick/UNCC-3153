using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Queens
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[,] board = BuildBoard(8, 8);
            PrintGrid(board);
        }

        private static int[,] BuildBoard(int row, int col)
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

        private static void PrintGrid(int[,] grid)
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
