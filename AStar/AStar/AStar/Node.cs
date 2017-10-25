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

        public int Distance(Node node)
        {
            // Manhattan Distance


            return Math.Abs(X - node.X) + Math.Abs(Y - node.Y);
               
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

            if (F < node.F)
                return 1;

            if (F == node.F)
                return 0;

            if (F > node.F)
                return -1;

            else
                throw new ArgumentException("Object not a Node.");
        }
    }
}
