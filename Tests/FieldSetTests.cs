using System.Linq;
using CowFields.Fields;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FieldSetTests
    {
        private FieldSet fieldSet;

        [TestInitialize]
        public void Initialize()
        {
            fieldSet = new FieldSet(4);
        }

        [TestMethod]
        public void Creates_All_Nodes()
        {
            Assert.IsTrue(fieldSet.Fields.Count == 4);
        }

        [TestMethod]
        public void Names_All_Fields()
        {
            for (int i = 1; i <= fieldSet.Fields.Count; i++)
            {
                Assert.IsTrue(fieldSet.Fields[i].Id == i);
            }
        }

        [TestMethod]
        public void Sets_Initial_Weight()
        {
            int expected = 4;

            // Connect fields 1 and 2, weight 4
            fieldSet.NewEdge(1, 2, 4);

            Assert.AreEqual(expected, fieldSet.Fields[1].Edges[2]);
            Assert.AreEqual(expected, fieldSet.Fields[2].Edges[1]);
        }

        [TestMethod]
        public void Updates_Weight_If_Shorter()
        {
            int expected = 2;

            fieldSet.NewEdge(1, 2, 4);
            fieldSet.NewEdge(1, 2, 2);

            Assert.AreEqual(expected, fieldSet.Fields[1].Edges[2]);
            Assert.AreEqual(expected, fieldSet.Fields[2].Edges[1]);
        }

        [TestMethod]
        public void Ignores_Longer_Weight()
        {
            int expected = 2;

            fieldSet.NewEdge(1, 2, 2);
            fieldSet.NewEdge(1, 2, 4);

            Assert.AreEqual(expected, fieldSet.Fields[1].Edges[2]);
            Assert.AreEqual(expected, fieldSet.Fields[2].Edges[1]);
        }

        [TestMethod]
        public void Visits_Nothing_In_New_FieldSet()
        {
            int expected = 0;

            int actual = fieldSet.Fields.Count(f => f.Value.Visited);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Visits_Two_With_One_Instruction()
        {
            int expected = 2;

            fieldSet.NewEdge(1, 2, 2);
            int actual = fieldSet.Fields.Count(f => f.Value.Visited);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Visits_Two_With_Two_Instructions()
        {
            int expected = 2;

            fieldSet.NewEdge(1, 2, 2);
            fieldSet.NewEdge(1, 2, 4);
            int actual = fieldSet.Fields.Count(f => f.Value.Visited);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Visits_All_Nodes()
        {
            bool expected = true;

            fieldSet.NewEdge(1, 2, 2);
            fieldSet.NewEdge(2, 3, 4);
            fieldSet.NewEdge(2, 4, 4);
            bool actual = fieldSet.AllVisited;

            // Check bool flag
            Assert.AreEqual(expected, actual);

            // Check individual nodes
            Assert.AreEqual(true, fieldSet.Fields.All(f => f.Value.Visited));
        }

    }
}
