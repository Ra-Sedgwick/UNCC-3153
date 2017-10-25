using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public bool IsPassable { get; set; }

        public Node(int x, int y, bool isPassable)
        {
            X = x;
            Y = y;
            IsPassable = isPassable;
        }

        public override bool Equals(object obj)
        {
            Node node = (Node)obj;
            return X == node.X && Y == node.Y;
        }


    }
}
