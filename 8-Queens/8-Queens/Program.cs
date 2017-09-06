﻿using System;
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
            Board Board = new Board();
            Board.Print();
            var result = Board.CheckGoalState();

            Console.ReadKey();

        }




        public static List<int[]> GetQueens(int[,] grid)
        {
            List<int[]> Queens = new List<int[]>();


            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[c, r] == 1)
                    {
                        int[] queen = new int[] { r, c };
                        Queens.Add(queen);
                    }
                }
            }

            return Queens;

        }


        //// No queen occupies same Row, Col, Diag
        //public static bool CheckGoalState(int[,] grid, List<int[,]> Queens)
        //{
        //    // To check if two queens are on the same diagonal check
        //    // the difference between the rows and columns fo the two queens.
        //    // if they are they same they are on the same diagonal. 

        //    // Check Row

        //    // Check Col

        //    // Check Diag

        //    return true;
        //}

        //public static void PrintGrid(int[,] grid)
        //{
        //    for (int i = 0; i < grid.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < grid.GetLength(1); j++)
        //            Console.Write(grid[i, j] + " ");

        //        Console.WriteLine();
        //    }
        //}
    }
}


