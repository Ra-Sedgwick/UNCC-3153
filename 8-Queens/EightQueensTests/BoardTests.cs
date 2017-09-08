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
        public void GetQueensTest()
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

            // Assert
            for (int i = 0; i < size; i++)
            {
                CollectionAssert.AreEqual(Board.Queens[i], TargetQueens[i]);
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
            Assert.IsNotNull(TrueSolutionConflicts);
            Assert.AreNotEqual(FalseSolutionConflicts.Count, 0);
        }
    }

    class Helpers
    {
        public static Board GetTrueSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.SetRow(0, new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 });
            Board.SetRow(1, new List<int> { 0, 0, 0, 1, 0, 0, 0, 0 });
            Board.SetRow(2, new List<int> { 0, 0, 0, 0, 0, 0, 1, 0 });
            Board.SetRow(3, new List<int> { 1, 0, 0, 0, 0, 0, 0, 0 });
            Board.SetRow(4, new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 });
            Board.SetRow(5, new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 });
            Board.SetRow(6, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 });
            Board.SetRow(7, new List<int> { 0, 0, 1, 0, 0, 0, 0, 0 });

            return Board;
        }

        public static Board GetFalseSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.SetRow(0, new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 });
            Board.SetRow(1, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 });
            Board.SetRow(2, new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 });
            Board.SetRow(3, new List<int> { 1, 0, 0, 0, 0, 0, 0, 0 });
            Board.SetRow(4, new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 });
            Board.SetRow(5, new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 });
            Board.SetRow(6, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 });
            Board.SetRow(7, new List<int> { 0, 0, 1, 0, 0, 0, 0, 0 });

            return Board;
        }
    }
    
}