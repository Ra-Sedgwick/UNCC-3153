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
            Console.WriteLine(Board);
            var move = Board.NeighborStates.Min(state => state.Conflicts.Count);
            Console.ReadKey();
        }

        

    }
}


