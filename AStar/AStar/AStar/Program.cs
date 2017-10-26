using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Program
    {
        private static int Size = 15;

        static void Main(string[] args)
        {
            bool run;
            int startX = -1;
            int startY = -1;
            int endX = -1;
            int endY = -1;

            do
            {
                Board board = new Board(15);

                while (startX < 0 || startX > 14)
                {
                    Console.Write("Please enter start node x coordinate, 0 -> 14: ");
                    startX = Convert.ToInt32(Console.ReadLine());
                }

                while (startY < 0 || startY > 14)
                {
                    Console.Write("Please enter start node y coordinate, 0 -> 14: ");
                    startY = Convert.ToInt32(Console.ReadLine());
                }


                while (endX < 0 || endX > 14)
                {
                    Console.Write("Please enter end node x coordinate, 0 -> 14: ");
                    endX = Convert.ToInt32(Console.ReadLine());
                }

                while (endY < 0 || endY > 14)
                {
                    Console.Write("Please enter end node y coordinate, 0 -> 14: ");
                    endY = Convert.ToInt32(Console.ReadLine());
                }
                
                Node start = new Node(startX, startY, true);
                Node end = new Node(endX, endY, true);
                List<Node> path;

                board.Initialize(start, end);

                path = board.GetPath();

                if (path == null)
                {
                    Console.WriteLine(board);
                    Console.WriteLine("No Path To Goal");
                }
                else
                    board.PrintPath(path);

                Console.WriteLine("Generate another board?, 1 : Yes - 0 : No");
                int r = Convert.ToInt32(Console.ReadLine());
                run = r == 1;
            }
            while (run);

           


           

        }
    }
}
