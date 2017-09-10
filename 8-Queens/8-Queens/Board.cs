using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueens
{
    public class Board
    {
        public List<List<int>> State { get; set; }
        public List<int[]> Queens { get; set; }
        public List<Board> NeighborStates { get; set; }

        // Wrapper around Dictionary, Key: Queen coordinates, Value: List of conflicting queens by coordinates.
        public Conflicts Conflicts { get; set; }


        public Board(int _size)
        {
            BuildState(_size);
            GetQueens();
            CheckGoalState();
            GetNeighborStates();

        }

        // Copy Constructor
        public Board(Board _board)
        {
            this.State = new List<List<int>>();

            _board.State.ForEach(x => {
                this.State.Add(new List<int>(x));
            });

            GetQueens();
            CheckGoalState();
        }

        public bool SetCell(int row, int col, int value)
        {
            if ( (value == 0 || value == 1) &&
                 (row >= 0 && row < this.State.Count) &&
                 (col >= 0 && col < this.State.Count) )
            {
                this.State[row][col] = value;
                GetQueens();
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
            this.Queens = new List<int[]>();

            for (int row = 0; row < State.Count(); row++)
                for (int col = 0; col < State.Count; col++)
                    if (State[col][row] == 1)
                    {
                        var queen = new int[] { row, col };
                        this.Queens.Add(queen);
                    }
        }

        public void GetNeighborStates()
        {
            this.NeighborStates = new List<Board>();

            for (int q = 0; q < Queens.Count; q++)
            {
                int Floor = this.Queens[q][1] * -1;
                int Ceiling = (this.Queens.Count - 1) - this.Queens[q][1];

                for (int i = Floor; i < Ceiling; i++)
                {
                    Board NewState = new Board(this);
                    NewState.MoveQueen(q, i);
                    this.NeighborStates.Add(NewState);
                }
            }

            this.NeighborStates.OrderBy(board => board.Conflicts.Table.Count);
        }

        public bool MoveQueen(int _queen, int _distance)
        {
            int[] queen = this.Queens[_queen];
            int newRow = queen[1] + _distance;

            if (newRow >= 0 && newRow <= this.State.Count)
            {
                SetCell(newRow, queen[0], 1);
                SetCell(queen[1], queen[0], 0);
                return true;
            }

            return false;
        }


        public void CheckGoalState()
        {
            this.Conflicts = new Conflicts();

            for (int i = 0; i < Queens.Count; i++)
            {
                var SubList = Queens.GetRange(i, Queens.Count - i);
                for (int j = 1; j < SubList.Count; j++)
                {
                    // Check Columns
                    if (SubList[0][0] == SubList[j][0])
                        this.Conflicts.Add(i, SubList[j]);

                    // Check Rows
                    if (SubList[0][1] == SubList[j][1])
                        this.Conflicts.Add(i, SubList[j]);

                    // Check Descending Diagnonal 
                    if (SubList[0][0] - SubList[0][1] == SubList[j][0] - SubList[j][1])
                        this.Conflicts.Add(i, SubList[j]);

                    // Check Ascending Diagonal
                    if (SubList[0][0] + SubList[0][1] == SubList[j][0] + SubList[j][1])
                        this.Conflicts.Add(i, SubList[j]);
                }
            }
        }


        public void Print()
        {
            foreach (var subList in State)
                Console.WriteLine(String.Join(" ", subList));
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Current Conflicts: ");
            sb.Append(this.Conflicts.Table.Count);
            sb.Append("\nCurrent State:\n");

            this.State.ForEach(subList =>
            {
                sb.Append(String.Join(" ", subList));
                sb.Append("\n");
            });

            return sb.ToString();
        }


    }
}
