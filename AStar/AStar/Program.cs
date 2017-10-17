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
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(14, 14);
            board.Initialize(start, end);
            Console.WriteLine(board);

            Console.ReadKey();

        }
    }
}
