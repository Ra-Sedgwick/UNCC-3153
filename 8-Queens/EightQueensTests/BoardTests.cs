using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EightQueens.Tests
{
    [TestClass()]
    public class BoardTests
    {

        [TestMethod()]
        public void BoardTest()
        {
            // Arrange
            int size = 8;
            Board Board = new Board(size);
            int[] Queens = new int[size];

            // Act, Sum queens in each column, assign to correspoding
            //      array position. 
            for(int i = 0; i < size; i++)
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
    }
}