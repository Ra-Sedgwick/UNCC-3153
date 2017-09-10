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


