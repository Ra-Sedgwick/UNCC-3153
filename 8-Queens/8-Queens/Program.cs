using System;
using System.Linq;
using System.Collections.Generic;

namespace EightQueens
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board(8);

            do
            {
                Board.GetNeighborStates();
                Console.WriteLine(Board);

                var BetterStates = Board.Neighbors.Table
                    .Where(state => state.Conflicts < Board.Conflicts)
                    .ToList();

                if (BetterStates.Any())
                    Board = new Board(Board.Neighbors.Table.Min);

            } while (Board.Conflicts != 0);

            Console.WriteLine("Solution Fountd");
            Console.Write(Board);

            Console.ReadKey();
        }

        

    }
}


