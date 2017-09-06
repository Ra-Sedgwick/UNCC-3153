using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EightQueens.Tests
{
    [TestClass()]
    public class BoardTests
    {

        [TestMethod()]
        public void BoardStateTest()
        {
            // Arrange
            int size = 8;
            Board Board = new Board(size);
            int[] Queens = new int[size];

            // Act, Sum queens in each column, assign to correspoding
            //      array position. 
            for (int i = 0; i < size; i++)
            {
                foreach (var Row in Board.State)
                {
                    Queens[i] += Row[i];
                }
            }

            // Assert, One queen in each column. 
            foreach (int queen in Queens)
            {
                Assert.AreEqual(queen, 1);
            }
        }

        [TestMethod()]
        public void BoardQueensTest()
        {
            // Arrange
            int size = 8;
            Board Board = Helpers.GetTrueSolution(size);

            // Act
            var TargetQueens = new List<int[]>
            {
                new int[] { 0, 5 },
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 3, 0 },
                new int[] { 4, 7 },
                new int[] { 5, 1 },
                new int[] { 6, 4 },
                new int[] { 7, 2 }
            };

            var TestQueens = Board.GetQueens();

            // Assert
            for (int i = 0; i < size; i++)
            {
                CollectionAssert.AreEqual(TestQueens[i], TargetQueens[i]);
            }
        }

        [TestMethod()]
        public void CheckGoalStateTest()
        {
            // Arrange
            int size = 8;
            Board TrueBoard = Helpers.GetTrueSolution(size);
            Board FalseBoard = Helpers.GetFalseSolution(size);

            // Act
            var TrueSolutionConflicts = TrueBoard.CheckGoalState();
            var FalseSolutionConflicts = FalseBoard.CheckGoalState();

            // Assert
            Assert.AreEqual(TrueSolutionConflicts.Count, 0);
            Assert.AreNotEqual(FalseSolutionConflicts, 0);
        }
    }

    class Helpers
    {
        public static Board GetTrueSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.State[0] = new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 };
            Board.State[1] = new List<int> { 0, 0, 0, 1, 0, 0, 0, 0 };
            Board.State[2] = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0 };
            Board.State[3] = new List<int> { 1, 0, 0, 0, 0, 0, 0, 0 };
            Board.State[4] = new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 };
            Board.State[5] = new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 };
            Board.State[6] = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 };
            Board.State[7] = new List<int> { 0, 0, 1, 0, 0, 0, 0, 0 };

            return Board;
        }

        public static Board GetFalseSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.State[0] = new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 };
            Board.State[1] = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 };
            Board.State[2] = new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 };
            Board.State[3] = new List<int> { 1, 0, 0, 0, 0, 0, 0, 0 };
            Board.State[4] = new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 };
            Board.State[5] = new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 };
            Board.State[5] = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 };
            Board.State[7] = new List<int> { 0, 0, 1, 0, 0, 0, 0, 0 };

            return Board;
        }
    }
    
}