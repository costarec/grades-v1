using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics results = book.ComputeStatistics();
            Assert.AreEqual(90, results.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics results = book.ComputeStatistics();
            Assert.AreEqual(10, results.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);      // int can convert to float safely
            book.AddGrade(89.5f);   // double can't convert to float safely
            book.AddGrade(75);

            GradeStatistics results = book.ComputeStatistics();
            Assert.AreEqual(85.16, results.AverageGrade, 0.01);
        }

    }
}
