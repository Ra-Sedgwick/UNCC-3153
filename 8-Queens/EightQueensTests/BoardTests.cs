using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Diagnostics;

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
                new int[] { 0, 3 },
                new int[] { 1, 5 },
                new int[] { 2, 7 },
                new int[] { 3, 1 },
                new int[] { 4, 6 },
                new int[] { 5, 0 },
                new int[] { 6, 2 },
                new int[] { 7, 4 }
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
            var TrueSolutionConflicts = TrueBoard.Conflicts.Table.Count;
            var FalseSolutionConflicts = FalseBoard.Conflicts.Table.Count;

            // Assert
            Assert.IsNotNull(TrueSolutionConflicts);
            Assert.AreNotEqual(FalseSolutionConflicts, 0);
        }

        [TestMethod()]
        public void MoveQueenTest()
        {
            // Arrange
            int Size = 8;
            bool LegalUp;
            bool IllegalUp;
            bool LegalDown;
            bool IllegalDown;
            Board Board = Helpers.GetTrueSolution(Size);

            // Act
            LegalUp = Board.MoveQueen(0, -2);
            IllegalUp = Board.MoveQueen(0, -2);
            LegalDown = Board.MoveQueen(1, 2);
            IllegalDown = Board.MoveQueen(1, 2);



            // Assert
            Assert.AreEqual(LegalUp, true);
            Assert.AreEqual(IllegalUp, false);
            CollectionAssert.AreEqual(Board.Queens[0], new int[] { 0, 1 });

            Assert.AreEqual(LegalDown, true);
            Assert.AreEqual(IllegalDown, false);
            CollectionAssert.AreEqual(Board.Queens[1], new int[] { 1, 7 });
        }

        [TestMethod()]
        public void GetNeighborStatesTest()
        {
            // Arrange
            int size = 8;
            int PossibleStates = (size - 1) * size;
            Board TrueBoard = Helpers.GetTrueSolution(size);

            // Act
            var NeightborStates = TrueBoard.NeighborStates.Count;

            // Assert
            Assert.AreEqual(NeightborStates, PossibleStates);
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