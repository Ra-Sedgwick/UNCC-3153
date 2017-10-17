using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AStar
{
    class Cell
    {
        public Vector2 Position { get; set; }
        public bool IsPassable { get; set; }
        public bool IsStart { get; set; }
        public bool IsGoal { get; set; }
        public bool IsSprite { get; set; }

        public Cell(int x, int y, bool isPassable)
        {
            Position = new Vector2(x, y);
            IsPassable = isPassable;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Vector2 v = (Vector2)obj;
            return (Position.X == v.X) && (Position.Y == v.Y);
        }

        public String GetGraphic()
        {
            if (IsSprite)
                return "@";

            else if (IsStart)
                return "S";

            else if (IsGoal)
                return "G";

            return IsPassable ? "*" : "X"; 
        }

    }
}
