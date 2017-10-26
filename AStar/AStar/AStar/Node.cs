using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Node : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int? F { get; set; }  // G + H, pick lowest F
        public int? G { get; set; }  // Start to this node
        public int? H { get; set; }  // Start to goal node
        public Node Parent { get; set; }
        public bool IsPassable { get; set; }

        public Node(int x, int y, bool isPassable)
        {
            X = x;
            Y = y;
            IsPassable = isPassable;
        }

        public int EuclidianDistance(Node node)
        {
            int x = node.X;
            int y = node.Y;

            return (int)Math.Sqrt(
                    Math.Pow(X - x, 2) + Math.Pow(Y - y, 2)
                ) * 10;
        }

        public int ManhattanDistance(Node node)
        {
            return (Math.Abs(X - node.X) + Math.Abs(Y - node.Y)) * 10;
        }


        public override bool Equals(object obj)
        {
            Node node = (Node)obj;
            return X == node.X && Y == node.Y;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object is Null");

            Node node = obj as Node;

            if (F > node.F)
                return 1;

            if (F == node.F)
                return 0;

            if (F < node.F)
                return -1;

            else
                throw new ArgumentException("Object not a Node.");
        }

        public override string ToString()
        {
            return (IsPassable) ? $"[{X}, {Y}] F{F} G{G} H{H} P => [{Parent.X}, {Parent.Y}]" : $"Not Passible [{X}, {Y}]";
        }
    }
}
