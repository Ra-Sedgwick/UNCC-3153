using System;
using System.Linq;
using System.Collections.Generic;

namespace EightQueens
{
    public static class Program
    {
        static void Main(string[] args)
        {

            // TODO: Finding correct conflicts but NeighborStat.Conflicts still pointing to parent.
            Board Board = new Board(8);
            Board.GetNeighborStates();
            Console.WriteLine(Board);
            Console.WriteLine(Board.Conflicts);
            Console.WriteLine("\nNeighborStates");
            Board.NeighborStates.ForEach(s => {
                Console.WriteLine(s);
                Console.WriteLine(s.Conflicts);
                Console.WriteLine();
            });
            Console.ReadKey();
        }

        

    }
}


