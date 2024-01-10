using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace test_lab1_ex2
{
    [TestClass]
    public class rectangle_test
    {
        [TestMethod]
        public void Test_perimetr()
        {
            rectangle A = new rectangle(4.0, 5.0);
            double expected = 18.0;
            double actual = A.Perimetr;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void test_area()
        {
            rectangle A = new rectangle(4.0, 5.0);
            double expected = 20.0;
            double actual = A.Area;
            Assert.AreEqual(expected, actual);
        }
    }
}