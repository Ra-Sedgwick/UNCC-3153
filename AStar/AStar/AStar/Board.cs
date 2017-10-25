using MinHeap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Board
    {
        public int Size { get; set; }
        public Node Start { get; set; }
        public Node Goal { get; set; }
        public Node Sprite { get; set; }
        public List<List<Node>> State { get; set; }

        // Nodes Adjacent to Sprite 
        public MinHeap<Node> OpenList { get; set; }

        // Known Nodes
        public List<Node> ClosedList { get; set; }

        public Board(int size)
        {
            Size = size;
            State = new List<List<Node>>();
            OpenList = new MinHeap<Node>();
            ClosedList = new List<Node>();
        }

        public void Initialize(Node start, Node goal)
        {
            Start = start;
            Sprite = start;
            Goal = goal;

            for (int i = 0; i < Size; i++)
            {
                State.Add(new List<Node>());
                for (int j = 0; j < Size; j++)
                {
                    State[i].Add(new Node(i, j, true));
                }
            }

            SetImpassible();
        }

        

        public bool MoveSprite()
        {
            List<Node> possibleMoves = GetWalkableNodes(Sprite);

            possibleMoves.ForEach(n =>
            {
                if (!ClosedList.Contains(n))
                {
                    if (!OpenList.Contains(n))
                    {
                        GetF(n);
                        OpenList.Enqueue(n);
                    }
                }
            });

            int x = 10;
            throw new NotImplementedException();
        }

        public void SetImpassible()
        {
            int cellCount = (int) Math.Round(Size * Size * 0.1, 2);
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<Node> impassableCells = new List<Node>();
            Node v; 

            for (int i = 0; i < cellCount; i++)
            {
                while (true)
                {
                    v = new Node(random.Next(0, Size), random.Next(0, Size), false);
                    if (!impassableCells.Contains(v))
                    {
                        impassableCells.Add(v);
                        break;
                    }

                }
            }

            impassableCells.ForEach(c => {
                State[c.X][c.Y].IsPassable = false; 
            });

        }

        public List<Node> GetWalkableNodes(Node node)
        {
            int x, y;
            List<Node> moves = new List<Node>();

            // Move up
            x = node.X;
            y = node.Y - 1;

            if (IsLegalMove(x, y))
                moves.Add(State[x][y]);

            // Move right
            x = node.X + 1;
            y = node.Y;

            if (IsLegalMove(x, y))
                moves.Add(State[x][y]);

            // Move down
            x = node.X;
            y = node.Y + 1;

            if (IsLegalMove(x, y))
                moves.Add(State[x][y]);

            // Move left
            x = node.X - 1;
            y = node.Y;

            if (IsLegalMove(x, y))
                moves.Add(State[x][y]);

            return moves;
        }

        public int? GetG(Node node)
        {
            if (node.G != null)
                return node.G;

            node.G = node.Distance(Start);
            return node.G;

        }

        public int? GetH(Node node)
        {
            if (node.H != null)
                return node.H;

            node.H = node.Distance(Goal);
            return node.H;
        }

        public int? GetF(Node node)
        {
            if (node.F != null)
                return node.F;

            node.F = GetG(node) + GetH(node);
            return node.F;
        }

        private bool IsLegalMove(int x, int y)
        {
            return (x >= 0 && x < Size) && (y >= 0 && y < Size);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (List<Node> rows in State)
            {
                foreach (Node node in rows)
                {
                    if (node.Equals(Start) && Start.Equals(Sprite))
                        sb.Append("S/@");

                    else if (node.Equals(Goal) && Goal.Equals(Sprite))
                        sb.Append("G/@");

                    else if (node.Equals(Start))
                        sb.Append("S");

                    else if (node.Equals(Goal))
                        sb.Append("G");

                    else if (node.Equals(Sprite))
                        sb.Append("@");

                    else if (node.IsPassable)
                        sb.Append("*");

                    else
                        sb.Append("X");

                    sb.Append(" ");
                }
                sb.AppendLine();
            }


            return sb.ToString();
        }
    }
}
