using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodEqualsTests
    {
        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(0, 59, 59, 0, 59, 59)]
        public void EqualsTimePeriod_WhenValuesItsCorrectThreeParameters_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0, 0, 0)]
        [DataRow(23, 0, 23, 0)]
        [DataRow(23, 59, 23, 59)]
        [DataRow(0, 59, 0, 59)]
        public void EqualsTimePeriod_WhenValuesItsCorrectTwoParameters_ShouldReturnTrue(
            int t1Hours, int t1Minutes,
            int t2Hours, int t2Minutes)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0)]
        [DataRow(23, 23)]
        [DataRow(1, 1)]
        public void EqualsTimePeriod_WhenValuesItsCorrectOneParameters_ShouldReturnTrue(
            int t1Hours,
            int t2Hours)
        {
            TimePeriod t1 = new TimePeriod(t1Hours);
            TimePeriod t2 = new TimePeriod(t2Hours);
            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod, TestCategory("Equals")]
        public void EqualsTimePeriod_WhenValuesItsCorrectDefault_ShouldReturnTrue()
        {
            TimePeriod t1 = new TimePeriod();
            TimePeriod t2 = new TimePeriod();
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, -1, 0, 0, -1, 0)]
        [DataRow(0, -1, -1, 0, -1, -1)]
        [DataRow(-1, -1, -1, -1, -1, -1)]
        [DataRow(24, 60, 59, 24, 60, 59)]
        [DataRow(23, 59, 59, 23, 60, 59)]
        [DataRow(24, 60, 60, 24, 60, 60)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsTimePeriod_WhenValuesItsWrong_ShouldThrowArgumentOutOfRangeException(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0, 0, 23, 0, 0)]
        [DataRow(0, 0, 0, 23, 0, 40)]
        [DataRow(0, 0, 0, 23, 10, 40)]
        [DataRow(0, 20, 0, 23, 0, 0)]
        [DataRow(0, 0, 30, 23, 0, 0)]
        [DataRow(8, 0, 0, 23, 0, 0)]
        [DataRow(20, 50, 11, 23, 59, 59)]
        public void EqualsTimePeriod_WhenValuesItsIncorrect_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
            Assert.IsFalse(t1.Equals(t2));
        }
    }
}