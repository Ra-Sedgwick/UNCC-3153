using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(15);
            Node start = new Node(0, 0, true);
            Node end = new Node(8, 8, true);
            board.Initialize(start, end);
            var x = board.GetWalkableNodes(board.Start);
            board.MoveSprite();
            Console.WriteLine(board);


            Console.ReadKey();

        }
    }
}
