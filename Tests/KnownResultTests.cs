using System;
using CowFields.Fields;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KnownResultTests
    {
        private FieldSet fieldSet;

        [TestInitialize]
        public void Initialize()
        {
            fieldSet = new FieldSet(4);
        }

        [TestMethod]
        public void Week0_No_Instructions()
        {
            int expected = -1;

            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week1()
        {
            int expected = -1;

            fieldSet.NewEdge(1, 2, 10);
            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week2()
        {
            int expected = -1;

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week3()
        {
            int expected = -1;

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            fieldSet.NewEdge(3, 2, 3);

            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week4()
        {
            int expected = 14;

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            fieldSet.NewEdge(3, 2, 3);
            fieldSet.NewEdge(1, 4, 3);

            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week5()
        {
            int expected = 12;

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            fieldSet.NewEdge(3, 2, 3);
            fieldSet.NewEdge(1, 4, 3);
            fieldSet.NewEdge(1, 3, 6);

            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Week6()
        {
            int expected = 8;

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            fieldSet.NewEdge(3, 2, 3);
            fieldSet.NewEdge(1, 4, 3);
            fieldSet.NewEdge(1, 3, 6);
            fieldSet.NewEdge(2, 1, 2);

            int actual = fieldSet.Solve();

            Assert.AreEqual(expected, actual);
        }
    }
}
