using System;
using System.Linq;
using System.Collections.Generic;

namespace EightQueens
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board();
            Board.GetNeighborStates();
            Console.ReadKey();
        }

        

    }
}


