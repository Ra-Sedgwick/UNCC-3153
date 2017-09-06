using Microsoft.VisualStudio.TestTools.UnitTesting;
using EightQueens;
using System.Linq;
using _8_Queens;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void SetUpBoard()
        {
            // Arrange
            int size = 8;
            Board
            

            // Act, Queens are represented by 1, sum 1's in each column.
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    if (Board[r, c] == 1)
                        Queens[c] += 1;

                    GridSum += Board[r, c];
                }

            // Assert, One queen in each column, Cols total.
            foreach (int i in Queens)
                Assert.AreEqual(i, 1);

            Assert.AreEqual(GridSum, Cols);
        }


    }
}
