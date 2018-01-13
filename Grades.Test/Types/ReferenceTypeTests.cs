using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;

            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);

        }

        private void AddGrades(float[] grades)
        {
            //grades = new float[5];
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            String name = "chuck costarella";
            String name2 = name.ToUpper();

            Assert.AreEqual("CHUCK COSTARELLA", name2);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2002, 8, 22);
            date = date.AddDays(1);

            Assert.AreEqual(23, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;    // this change is operating on a copy.
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("Empty Grade Book", book1.Name);
            
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "Empty Grade Book";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Chuck";
            string name2 = "chuck";
            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }


        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;
            g1.Name = "Chuck's GradeBook";


            g1 = new GradeBook();
            g1.Name = "Chuck's GradeBook";
            Assert.AreEqual(g1.Name, g2.Name);

        }
    }
}
