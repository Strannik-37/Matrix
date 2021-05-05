using System;
using MatrixClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestsMatrix
{
    [TestClass]
    public class Matrix_Tests
    {
        [TestMethod]
        public void Index()
        {
            //arrange
            Matrica<int> a = new Matrica<int>();
            a.Create(5, 5);
            a[1, 2] = 100;
            int expected = 100;

            //act
            int actual = a[1, 2];

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sum_Dimen_mis()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(5, 5);
            b.Create(4, 5);
            Matrica<double> c;

            //act
            c = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Mult_Dimen_mis()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(5, 5);
            b.Create(4, 5);
            Matrica<double> c;

            //act
            c = a * b;
        }

        [TestMethod]
        public void Sum_Matr_2_2()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(2, 2);
            b.Create(2, 2);
            Matrica<double> expected;
            Matrica<double> actual = new Matrica<double>();
            actual.Create(2, 2);

            //act
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = 1;
                    b[i, j] = 1;
                    actual[i, j] = 2;
                }
            expected = a + b;

            //assert
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
        }

        [TestMethod]
        public void Mult_Matr_2_2()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(2, 2);
            b.Create(2, 2);
            Matrica<double> expected;
            Matrica<double> actual = new Matrica<double>();
            actual.Create(2, 2);

            //act
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = 1;
                    b[i, j] = 1;
                    actual[i, j] = 2;
                }
            expected = a * b;

            //assert
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
        }

        [TestMethod]
        public void Sum_Negative_Matr_2_2()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(2, 2);
            b.Create(2, 2);
            Matrica<double> expected;
            Matrica<double> actual = new Matrica<double>();
            actual.Create(2, 2);

            //act
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = 1;
                    b[i, j] = 1;
                    actual[i, j] = 0;
                }
            expected = a + b;

            //assert
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreNotEqual(expected[i, j], actual[i, j]);
                }
        }

        [TestMethod]
        public void Mult_Negative_Matr_2_2()
        {
            //arrange
            Matrica<double> a = new Matrica<double>();
            Matrica<double> b = new Matrica<double>();
            a.Create(2, 2);
            b.Create(2, 2);
            Matrica<double> expected;
            Matrica<double> actual = new Matrica<double>();
            actual.Create(2, 2);

            //act
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = 1;
                    b[i, j] = 1;
                    actual[i, j] = 0;
                }
            expected = a * b;

            //assert
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreNotEqual(expected[i, j], actual[i, j]);
                }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Negarive_mis()
        {
            Matrica<double> a = new Matrica<double>();
            a.Create(-5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Negative_Type()
        {
            //arrange
            Matrica<string> a = new Matrica<string>();
            a.Create(5, 5);
        }

        [TestMethod]
        public void Random_2_2()
        {
            //arrange
            Matrica<int> actual = new Matrica<int>();
            actual.Create(2, 2);
            Matrica<int> expected = new Matrica<int>();
            expected.Create(2, 2);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    expected[i, j] = i + j;

            //act
            actual.Generation((x, y) => x + y);

            //assert
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
        }

    }
}
