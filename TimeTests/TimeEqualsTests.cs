using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests.TimeTests
{
    [TestClass]
    public class TimeEqualsTests
    {
        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(0, 59, 59, 0, 59, 59)]
        public void EqualsTime_WhenValuesItsCorrectThreeParameters_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time t1 = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0, 0, 0)]
        [DataRow(23, 0, 23, 0)]
        [DataRow(23, 59, 23, 59)]
        [DataRow(0, 59, 0, 59)]
        public void EqualsTime_WhenValuesItsCorrectTwoParameters_ShouldReturnTrue(
            int hours, int minutes,
            int expectedHours, int expectedMinutes)
        {
            Time t1 = new Time((byte)hours, (byte)minutes);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0)]
        [DataRow(23, 23)]
        [DataRow(1, 1)]
        public void EqualsTime_WhenValuesItsCorrectOneParameters_ShouldReturnTrue(
            int hours,
            int expectedHours)
        {
            Time t1 = new Time((byte)hours);
            Time t2 = new Time((byte)expectedHours);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, 0)]
        [DataRow(23, 23)]
        [DataRow(1, 1)]
        public void EqualsTime_WhenValuesItsCorrectDefault_ShouldReturnTrue(
            int hours,
            int expectedHours)
        {
            Time t1 = new Time((byte)hours);
            Time t2 = new Time((byte)expectedHours);
            Assert.IsTrue(t1.Equals(t2));
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(0, -1, 0, 0, -1, 0)]
        [DataRow(0, -1, -1, 0, -1, -1)]
        [DataRow(-1, -1, -1, -1, -1, -1)]
        [DataRow(24, 59, 59, 24, 59, 59)]
        [DataRow(24, 60, 59, 24, 60, 59)]
        [DataRow(23, 59, 59, 23, 60, 59)]
        [DataRow(24, 60, 60, 24, 60, 60)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsTime_WhenValuesItsWrong_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time t1 = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds);
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
        public void EqualsTime_WhenValuesItsIncorrect_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time t1 = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds);
            Assert.IsFalse(t1.Equals(t2));
        }
    }
}