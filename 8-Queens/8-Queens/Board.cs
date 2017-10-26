using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueens
{
    public class Board
    {
        public List<List<int>> State { get; set; }
        public List<Queen> Queens { get; set; }
        public NeighborStates Neighbors { get; set; }
        public int Conflicts { get; set; }

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

            _board.State.ForEach(row => State.Add( new List<int>(row) ));

            GetQueens();
            GetConflits();
        }

        public bool SetCell(int row, int col, int value)
        {
            if ( (value == 0 || value == 1) &&
                 (row >= 0 && row < State.Count) &&
                 (col >= 0 && col < State.Count) )
            {
                State[row][col] = value;
                GetQueens();
                GetConflits();
                return true;
            }

            return false;
        }

        public bool SetRow(int index, List<int> row)
        {
            if (index >= 0 && index < State.Count)
            {
                State[index] = row;
                GetQueens();
                GetConflits();
                return true;
            }

            return false;
        }

        private void BuildState(int _size)
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
                int SkipIndex = Floor + Queens[q].Y;
                int Ceiling = (Queens.Count) - Queens[q].Y;

                for (int i = Floor; i < Ceiling; i++)
                {
                    if (i != SkipIndex)
                    {
                        Board NewState = new Board(this);
                        NewState.MoveQueen(q, i);
                        Neighbors.Table.Add(NewState);
                    }
                }
            }
        }

        public bool MoveQueen(int _queen, int _distance)
        {
            Queen queen = Queens[_queen];
            int newRow = queen.Y + _distance;

            if (newRow > 7 || newRow < 0)
            {
                Console.WriteLine("error");
            }

            if (newRow >= 0 && newRow <= State.Count)
            {
                SetCell(newRow, queen.X, 1);
                SetCell(queen.Y, queen.X, 0);
               // this.Print();
               // if (Queens.Count != 8)
               // {
               //     Console.WriteLine("Error: " + Queens.Count);

               // }
               //// Console.ReadKey();
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
            StringBuilder sb = new StringBuilder();

            sb.Append("Current State:\n");

            this.State.ForEach(subList =>
            {
                sb.Append(String.Join(" ", subList));
                sb.Append("\n");
            });

            Console.WriteLine(sb);
        }

        public void PrintConflicts()
        {
            StringBuilder sb = new StringBuilder();
            
            if (Conflicts > 0)
            {
                sb.Append("Conflicts: ");
                sb.Append(Conflicts);
                sb.AppendLine();

                Queens.ForEach(queen => {
                   

                    if (queen.Conflicts.Any())
                    {
                        sb.Append("Queen:  ");
                        sb.Append(queen.X);
                        sb.Append("-");
                        sb.Append(queen.Y);
                        sb.Append(", conflicts at:\n");
                        foreach (var conflict in queen.Conflicts)
                        {
                            sb.Append("\t");
                            sb.Append(conflict.X);
                            sb.Append("-");
                            sb.Append(conflict.Y);
                            sb.AppendLine();
                        }
                        sb.AppendLine();
                    }

                });
            }
            else
            {
                sb.Append("No Conflicts");
            }

            Console.Write(sb);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("Current State:\n");

            this.State.ForEach(subList =>
            {
                sb.Append(String.Join(" ", subList));
                sb.Append("\n");
            });

            sb.Append("\n");
   

            return sb.ToString();
        }


    }
}
