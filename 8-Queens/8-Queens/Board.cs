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

        // Wrapper around Dictionary, Key: Queen coordinates, Value: List of conflicting queens by coordinates.
        public Conflicts Conflicts { get; set; }
        public Board()
        {
            this.State = BuildState(8);
            this.Queens = GetQueens();
            this.Conflicts = CheckGoalState();
            
        }

        public Board(int _size)
        {
            this.State = BuildState(_size);
            this.Queens = GetQueens();
            this.Conflicts = CheckGoalState();

        }

        public void SetCell(int row, int col, int value)
        {
            if (value == 0 || value == 1)
            {
                this.State[row][col] = value;
            }

            this.Queens = GetQueens();
        }

        public void SetRow(int index, List<int> row)
        {
            this.State[index] = row;
            this.Queens = GetQueens();
        }

        private List<List<int>> BuildState(int _size)
        {
            State = new List<List<int>>();
            Random Random = new Random();

            // Initialzie board state with all zeros.
            for (int i = 0; i < _size; i++)
            {
                var SubList = Enumerable.Repeat(0, _size).ToList();
                State.Add(SubList);

            }

            // Place one queen in each column.
            for (int i = 0; i < _size; i++)
            {
                int queen = Random.Next(0, _size);
                State[queen][i] = 1;
            }

            return State;
        }

        private List<int[]> GetQueens()
        {
            var Queens = new List<int[]>();


            for (int row = 0; row < State.Count(); row++)
                for (int col = 0; col < State.Count; col++)
                    if (State[col][row] == 1)
                    {
                        var queen = new int[] { row, col };
                        Queens.Add(queen);
                    }

            return Queens;
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


        public Conflicts CheckGoalState()
        {

            var Conflicts = new Conflicts();

            for (int i = 0; i < Queens.Count; i++)
            {
                var SubList = Queens.GetRange(i, Queens.Count - i);

                for (int j = 1; j < SubList.Count; j++)
                {
                    // Check Rows
                    if (SubList[0][0] == SubList[j][0])
                        Conflicts.Add(i, SubList[j]);

                    // Check Columns
                    if (SubList[0][1] == SubList[j][1])
                        Conflicts.Add(i, SubList[j]);

                    // Check Descending Diagnonal 
                    if (SubList[0][0] - SubList[0][1] == SubList[j][0] - SubList[j][1])
                        Conflicts.Add(i, SubList[j]);

                    // Check Ascending Diagonal
                    if (SubList[0][0] + SubList[0][1] == SubList[j][0] + SubList[j][1])
                        Conflicts.Add(i, SubList[j]);
                }
            }

            return Conflicts;
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
