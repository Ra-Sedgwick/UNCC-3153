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
            Board Board = new Board(size);

            // Act
            int QueenCount = Board.Queens.Count;

            // Assert
            Assert.AreEqual(QueenCount, size);
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
            Assert.Fail();
        }
    }

    class Helpers
    {
        public static Board GetTrueSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.State[0] = new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 };
            Board.State[1] = new List<int> { 0, 0, 0, 1, 0, 0, 0, 0} ;
            Board.State[2] = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0 };
            Board.State[3] = new List<int> { 1, 0, 0, 0, 0, 0, 0, 0 };
            Board.State[4] = new List<int> { 0, 0, 0, 0, 0, 0, 0, 1 };
            Board.State[5] = new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 };
            Board.State[5] = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0 };
            Board.State[7] = new List<int> { 0, 0, 1, 0, 0, 0, 0, 0 };

            return Board;
        }

        public static Board GetFalseSolution(int _size)
        {
            Board Board = new Board(_size);

            Board.State[0] = [0, 0, 0, 0, 0, 1, 0, 0];
            Board.State[1] = [0, 0, 0, 0, 1, 0, 0, 0];
            Board.State[2] = [0, 0, 0, 0, 0, 0, 0, 1];
            Board.State[3] = [1, 0, 0, 0, 0, 0, 0, 0];
            Board.State[4] = [0, 0, 0, 0, 0, 0, 0, 1];
            Board.State[5] = [0, 1, 0, 0, 0, 0, 0, 0];
            Board.State[5] = [0, 0, 0, 0, 1, 0, 0, 0];
            Board.State[7] = [0, 0, 1, 0, 0, 0, 0, 0];

            return Board;
        }
    }
    
}