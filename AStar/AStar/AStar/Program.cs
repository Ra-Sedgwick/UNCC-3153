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
            Board board = new Board(15);
            Node start = new Node(0, 0, true);
            Node end = new Node(4, 4, true);
            List<Node> path;

            board.Initialize(start, end);
            Console.WriteLine(board);

            path = board.GetPath();

            if (path == null)
            {
                Console.WriteLine(board);
                Console.WriteLine("No Path To Goal");
            }
            else
                board.PrintPath(path);

            Console.ReadKey();


           

        }
    }
}
