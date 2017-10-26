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

        // Availible Moves
        public List<Node> OpenList { get; set; }

        // Nodes Already Moved to
        public Stack<Node> ClosedList { get; set; }

        public Board(int size)
        {
            Size = size;
            State = new List<List<Node>>();
            OpenList = new List<Node>();
            ClosedList = new Stack<Node>();
        }

        public void Initialize(Node start, Node goal)
        {
            Start = start;
            Sprite = start;
            Goal = goal;

            // Initialize All Nodes on board with coordinates and passible 
            for (int i = 0; i < Size; i++)
            {
                State.Add(new List<Node>());
                for (int j = 0; j < Size; j++)
                {
                    State[i].Add(new Node(i, j, true));
                }
            }

            // Set 10% of Nodes as Impassible
            SetImpassibleNodes();

            // Add Start Node to Open List
            GetF(Start);
            OpenList.Add(Start);

        }

        public List<Node> GetPath()
        {
            List<Node> path = AStar();

            while ( path == null )
            {

                path = AStar();

                if (OpenList.Count() == 0)
                    return null;

            };

            return path;
        }

        private List<Node> GeneratePath()
        {
            return null;
        }

        public List<Node> AStar()
        {
            List<Node> possibleMoves;

            // Pop off lowest F
            int? min = OpenList.Min(n => n.F);
            Node current = OpenList.Where(n => n.F == min).First();
            OpenList.Remove(current);

            // Check for goal
            if (current.Equals(Goal))
            {
                ClosedList.Push(current);
                return ClosedList.Reverse().ToList();
            }

            else
            {
                possibleMoves = GetPassibleNodes(current);

                possibleMoves.ForEach(n =>
                {
                    if (!ClosedList.Contains(n))        // Dont move to an already visited Node
                    {
                        GetF(n);
                        if (!OpenList.Contains(n))
                        {
                            n.Parent = current;
                            OpenList.Add(n);
                        }
                    }
                });
            }

            Sprite = current;

            ClosedList.Push(current);
            Console.WriteLine(this);

            return null;
        }

        private List<Node> GeneratePath(Node current)
        {
            throw new NotImplementedException();
        }

        public void SetImpassibleNodes()
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

        public List<Node> GetPassibleNodes(Node node)
        {
            int x, y;
            Node move;
            List<Node> moves = new List<Node>();

            // Move up
            x = node.X;
            y = node.Y - 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            } 
            catch (ArgumentOutOfRangeException) {}

            // Move top right
            x = node.X + 1;
            y = node.Y - 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move right
            x = node.X + 1;
            y = node.Y;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move Bottom right
            x = node.X + 1;
            y = node.Y + 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move down
            x = node.X;
            y = node.Y + 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move bottom left
            x = node.X - 1;
            y = node.Y + 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move left
            x = node.X - 1;
            y = node.Y;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            // Move top left
            x = node.X - 1;
            y = node.Y - 1;

            try
            {
                move = State[x][y];
                if (move.IsPassable)
                {
                    moves.Add(move);
                }
            }
            catch (ArgumentOutOfRangeException) { }

            return moves;
        }

        

        public int? GetG(Node node)
        {
            int? temp = 0;
            Node next = null;

            // No moves yet caluclate against start
            if (!ClosedList.Any())
            {
                node.G = node.EuclidianDistance(Start);
                return node.G;
            }

            else
            {
                next = ClosedList.First();
                temp += node.EuclidianDistance(next);
                while (next.Parent != null)
                {
                    next = next.Parent;
                    temp += next.G;
                }
            }

            // If previous G score compare with new
            if (node.G != null)
            {
                // If previous route was worse set new route, usually this will not be the case.
                if (node.G > temp)
                {
                    node.G = temp;
                }
            }
            else
            {
                node.G = temp;
            }
             
            return node.G;
        }

        public int? GetH(Node node)
        {
            if (node.H != null)
                return node.H;

            node.H = node.ManhattanDistance(Goal);
            return node.H;
        }

        public int? GetF(Node node)
        {
            node.F = GetG(node) + GetH(node);
            return node.F;
        }

        public void PrintPath(List<Node> path)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Path: Start = ");

            path.ForEach(n => sb.Append($"[{n.X}, {n.Y}] => "));
            sb.AppendLine("Goal!");

            Console.WriteLine(sb);

            path.ForEach(n => {
                Sprite = n;
                Console.WriteLine(this);
                Console.WriteLine("Press any key to advance...\n");
                Console.ReadKey();
            });

            Console.WriteLine(sb.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (List<Node> rows in State)
            {
                foreach (Node node in rows)
                {
                    if (node.Equals(Start) && Start.Equals(Sprite))
                        sb.Append("S");

                    else if (node.Equals(Goal) && Goal.Equals(Sprite))
                        sb.Append("Goal!!");

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
