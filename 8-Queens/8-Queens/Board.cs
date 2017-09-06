using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Board
    {
        public List<List<int>> State { get; set; }

        public Board()
        {
            this.State = BuildState(8);
        }

        public Board(int _size)
        {
            this.State = BuildState(_size);

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

        public void Print()
        {
            foreach (var subList in State)
            {
                Console.WriteLine(String.Join(" ", subList));
            }
        }

    }
}
