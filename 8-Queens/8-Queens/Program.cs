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
            Board.GetNeighborStates();

            //do
            //{
            //    Board.GetNeighborStates();
            //    Console.WriteLine(Board);

            //    var BetterStates = Board.NeighborStates
            //        .Where(state => state.Conflicts.Count < Board.Conflicts.Count)
            //        .ToList();

            //    if (BetterStates.Any())
            //        Board = new Board(Board.NeighborStates[0]);

            //} while (Board.Conflicts.Count != 0);

            //Console.WriteLine("Solution Fountd");
            //Console.Write(Board);
            
            Console.ReadKey();
        }

        

    }
}


