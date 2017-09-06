using Microsoft.VisualStudio.TestTools.UnitTesting;
using EightQueens;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void SetUpBoard()
        {
            // Arrange
            int Rows = 8;
            int Cols = 8;
            int GridSum = 0;
            int[,] Board = Program.BuildBoard(8, 8);
            int[] Queens = Enumerable.Repeat(0, Cols).ToArray();

            // Act, Queens are represented by 1, sum 1's in each column.
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    if (Board[r, c] == 1)
                        Queens[c] += 1;

                    GridSum += Board[r, c];
                }
                    
            // Assert, One queen in each column, Cols total.
            foreach(int i in Queens)
                Assert.AreEqual(i, 1);

            Assert.AreEqual(GridSum, Cols);
        }

        public void GetQueens(int[,] grid)
        {
            // Arrange;
            int Queens = 0;

            // Act, Sum up all queens on board
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    Queens += grid[r, c];
                }
            }

            // Assert, the number of queens should equal the number of columns
            Assert.AreEqual(Queens, Cols);

        }
    }
}
