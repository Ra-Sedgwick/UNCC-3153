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
        public Vector2 Start { get; set; }
        public Vector2 Goal { get; set; }
        public Vector2 Sprite { get; set; }
        public List<List<Cell>> State { get; set; }

        private readonly char spriteChar = '@';
        private readonly char goalChar = 'G';
        private readonly char startChar = 'S';



        public Board(int size)
        {
            Size = size;
            State = new List<List<Cell>>();
        }

        public void Initialize(Vector2 start, Vector2 goal)
        {
            Start = start;
            Sprite = start;
            Goal = goal;

            


            for (int i = 0; i < Size; i++)
            {
                State.Add(new List<Cell>());
                for (int j = 0; j < Size; j++)
                {
                    State[i].Add(new Cell(i, j, true));
                }
            }

            SetImpassible();
            State[start.X][start.Y].IsStart = true;
            State[start.X][start.Y].IsSprite = true;
            State[goal.X][goal.Y].IsGoal = true; 
        }

        

        public bool MoveSprite(Vector2 vector2)
        {
            throw new NotImplementedException();
        }

        public void SetImpassible()
        {
            int cellCount = (int) Math.Round(Size * Size * 0.1, 2);
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<Vector2> impassableCells = new List<Vector2>();
            Vector2 v; 

            for (int i = 0; i < cellCount; i++)
            {
                while (true)
                {
                    v = new Vector2(random.Next(0, Size), random.Next(0, Size));
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (List<Cell> rows in State)
            {
                foreach (Cell cell in rows)
                {
                    sb.Append(cell.GetGraphic());
                    sb.Append(" ");
                }
                sb.AppendLine();
            }

        

            return sb.ToString();
        }
    }
}
