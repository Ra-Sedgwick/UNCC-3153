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
            // Arragne
            int size = 8;
            Board Board = new Board(size);

            // Act
            int QueenCount = Board.Queens.Count;

            // Assert
            Assert.AreEqual(QueenCount, size);
        }
    }
}