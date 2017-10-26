using System;
using System.Linq;

namespace EightQueens
{
    public static class Program
    {
        public static Board Board = new Board(8);
        public static int StateChanges = 0;
        public static int Resets = 0;

        static void Main(string[] args)
        {
            do
            {
                Board.GetNeighborStates();
                Board.Print();
                Board.PrintConflicts();
                ProcessState();
                
            } while (Board.Conflicts != 0);

            PrintResult();
        }

        private static void ProcessState()
        {
            var BetterStates = Board.Neighbors.Table
                    .Where(state => state.Conflicts < Board.Conflicts)
                    .ToList();

            if (BetterStates.Any())
            {
                Console.WriteLine("States with fewer conflicts: " + BetterStates.Count);
                Console.WriteLine("Setting new state with " + Board.Neighbors.Table.Min.Conflicts + " conflicts\n");
                Board = new Board(Board.Neighbors.Table.Min);
                StateChanges++;
            }
            else
            {
                Console.WriteLine("Local minima reached, 0 states with fewer conflicts\nRandom Reset\n");
                Board = new Board(8);
                Resets++;
            }
        }
        
        public static void PrintResult()
        {
            Console.WriteLine("Solution Found!\n");
            Console.Write(Board);
            Console.WriteLine("State Changes: " + StateChanges);
            Console.WriteLine("Resets: " + Resets);
            Console.WriteLine("\nHit any key to quit");

            Console.ReadKey();

        }
    }
}


