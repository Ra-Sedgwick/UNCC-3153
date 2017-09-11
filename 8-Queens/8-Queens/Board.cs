using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueens
{
    public class Board
    {
        public List<List<int>> State { get; set; }
        //public List<int[]> Queens { get; set; }
        public List<Queen> Queens { get; set; }
        //public List<Board> NeighborStates { get; set; }
        public NeighborStates Neighbors { get; set; }

        public int Conflicts { get; set; }

        // Wrapper around Dictionary, Key: Queen coordinates, Value: List of conflicting queens by coordinates.
        //public Conflicts Conflicts { get; set; }


        public Board(int _size)
        {
            State = new List<List<int>>();
            Queens = new List<Queen>();
            Neighbors = new NeighborStates();
            Conflicts = 0;

            BuildState(_size);
            GetQueens();
            GetConflits();

        }

        // Copy Constructor
        public Board(Board _board)
        {
            State = new List<List<int>>();
            Queens = new List<Queen>();
            Neighbors = new NeighborStates();
            Conflicts = 0;

            _board.State.ForEach(row => {
                this.State.Add(new List<int>(row));
            });

            GetQueens();
            GetConflits();
        }

        public bool SetCell(int row, int col, int value)
        {
            if ( (value == 0 || value == 1) &&
                 (row >= 0 && row < this.State.Count) &&
                 (col >= 0 && col < this.State.Count) )
            {
                this.State[row][col] = value;
                GetQueens();
                GetConflits();
                return true;
            }

            return false;
        }

        public bool SetRow(int index, List<int> row)
        {
            if (index >= 0 && index < this.State.Count)
            {
                this.State[index] = row;
                GetQueens();
                GetConflits();
                return true;
            }

            return false;
        }

        private void BuildState(int _size)
        {
            this.State = new List<List<int>>();
            Random Random = new Random();

            // Initialzie board state with all zeros.
            for (int i = 0; i < _size; i++)
            {
                var SubList = Enumerable.Repeat(0, _size).ToList();
                this.State.Add(SubList);

            }

            // Place one queen in each column.
            for (int i = 0; i < _size; i++)
            {
                int queen = Random.Next(0, _size);
                this.State[queen][i] = 1;
            }
        }

        private void GetQueens()
        {
            Queens = new List<Queen>();

            for (int row = 0; row < State.Count(); row++)
                for (int col = 0; col < State.Count; col++)
                    if (State[col][row] == 1)
                        Queens.Add(new Queen(row, col));
        }


        // TODO: Checking Redundent States
        public void GetNeighborStates()
        {
            Neighbors = new NeighborStates();

            for (int q = 0; q < Queens.Count; q++)
            {
                int Floor = Queens[q].Y * -1;
                int Ceiling = (Queens.Count - 1) - Queens[q].Y;

                for (int i = Floor; i < Ceiling; i++)
                {
                    Board NewState = new Board(this);
                    NewState.MoveQueen(q, i);
                    Neighbors.Table.Add(NewState);
                }
            }

        }

        public bool MoveQueen(int _queen, int _distance)
        {
            Queen queen = Queens[_queen];
            int newRow = queen.Y + _distance;

            if (newRow >= 0 && newRow <= this.State.Count)
            {
                SetCell(newRow, queen.X, 1);
                SetCell(queen.Y, queen.X, 0);
                return true;
            }

            return false;
        }


        public void GetConflits()
        {
            Conflicts = 0;

            for (int i = 0; i < Queens.Count; i++)
            {
                var SubList = Queens.GetRange(i, Queens.Count - i);

                for (int j = 1; j < SubList.Count; j++)
                {
                    // Check Columns
                    if (SubList[0].X == SubList[j].X)
                        Queens[i].Conflicts.Add(SubList[j]);

                    // Check Rows
                    if (SubList[0].Y == SubList[j].Y)
                        Queens[i].Conflicts.Add(SubList[j]);

                    // Check Descending Diagnonal 
                    if (SubList[0].X - SubList[0].Y == SubList[j].X - SubList[j].Y)
                        Queens[i].Conflicts.Add(SubList[j]);

                    // Check Ascending Diagonal
                    if (SubList[0].X + SubList[0].Y == SubList[j].X + SubList[j].Y)
                        Queens[i].Conflicts.Add(SubList[j]);
                }
            }

            Queens.ForEach(queen => Conflicts += queen.Conflicts.Count);
        }


        public void Print()
        {
            foreach (var subList in State)
                Console.WriteLine(String.Join(" ", subList));
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            var BetterStates = new List<Board>();
            
            int BetterStateCount = (BetterStates.Any()) ? BetterStates.Count : 0;
            String NewStateMsg = "Setting new current state with conflict count: ";
            String RestartMsg = "Restart";

            sb.Append("\nCurrent State:\n");

            this.State.ForEach(subList =>
            {
                sb.Append(String.Join(" ", subList));
                sb.Append("\n");
            });

            sb.Append("\n");
            sb.Append(this.Conflicts);
            sb.Append("\nNeighbors found with fewer conflicts: ");
            sb.Append(BetterStateCount);
            sb.Append("\n");
            sb.Append((BetterStateCount == 0) ? RestartMsg : NewStateMsg);

            return sb.ToString();
        }


    }
}
