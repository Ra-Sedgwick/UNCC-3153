using System;

namespace EightQueens
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board();
            Board.Print();
            //Console.WriteLine("State Conflicts: " + Board.CheckGoalState().Count);

            Console.ReadKey();
        }
    }
}


