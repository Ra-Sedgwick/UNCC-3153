﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Board
    {
        public List<List<int>> State { get; set; }
        public List<int[]> Queens { get; set; }

        public Board()
        {
            this.State = BuildState(8);
            this.Queens = GetQueens();
        }

        public Board(int _size)
        {
            this.State = BuildState(_size);
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

        public List<int[]> GetQueens()
        {
            var Queens = new List<int[]>();

            for (int row = 0; row < State.Count(); row++)
            {
                for (int col = 0; col < State.Count; col++)
                {
                    if (State[row][col] == 1)
                    {
                        var queen = new int[] { row, col };
                        Queens.Add(queen);
                    }
                }
            }

            return Queens;
        }

        // Checks Board state for conflicting queen postions
        // Returns reust as a list of conflict coordinates. 

        // TODO: Am I checking diagonals in both directions?
        public List<int[]> CheckGoalState()
        {
            var Conflicts = new List<int[]>();

            for (int i = 0; i < Queens.Count; i++)
            {
                var SubList = Queens.GetRange(i, Queens.Count - i);
                int DiagonalIndex = Queens[i][0] - Queens[i][1];

                // Rows
                Conflicts.AddRange(
                    SubList.Where(x => x[0] == Queens[i][0])
                );

                // Columns
                Conflicts.AddRange(
                     SubList.Where(x => x[1] == Queens[i][1])
                );

                // Diagonal
                Conflicts.AddRange(
                    SubList.Where(x => x[0] - x[1] == DiagonalIndex)
                );
            }

            return Conflicts;
        }   

        public void Print()
        {
            foreach (var subList in State)
            {
                Console.WriteLine(String.Join(" ", subList));
            }
        }

    }
}
