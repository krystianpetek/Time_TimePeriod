using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodConstructorTests
    {
        #region ThreeParameters

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(8, 16, 59, 8, 16, 59)]
        [DataRow(8, 59, 16, 8, 59, 16)]
        [DataRow(23, 16, 1, 23, 16, 1)]
        [DataRow(8, 59, 59, 8, 59, 59)]
        [DataRow(23, 16, 59, 23, 16, 59)]
        [DataRow(23, 59, 1, 23, 59, 1)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        public void ConstructorThreeParameters_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
            long hours, long minutes, long seconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes, seconds);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(1, 1, 1, 1, 1, 2)]
        [DataRow(1, 1, 1, 1, 1, -1)]
        [DataRow(1, 1, 1, -1, -1, -1)]
        [DataRow(1, 1, 1, 3, 5, 2)]
        [DataRow(1, 1, 1, 23, 59, 59)]
        [DataRow(0, 0, 0, 12, 12, 10)]
        [DataRow(10, 12, 14, 0, 1, 59)]
        [DataRow(23, 59, 59, 24, 60, 60)]
        public void ConstructorThreeParameters_WhenGivenCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            long hours, long minutes, long seconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes, seconds);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 1, 1, -1, 1, 1)]
        [DataRow(1, -2, 1, 1, -2, 1)]
        [DataRow(0, 0, -1, 0, 0, -1)]
        [DataRow(230, 10, 60, 230, 10, 60)]
        [DataRow(23, 100, 59, 23, 100, 59)]
        [DataRow(23, 100, 10, 23, 100, 10)]
        [DataRow(23, 100, 50000, 23, 100, 50000)]
        [DataRow(24, 10, 100, 24, 10, 100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThreeParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            long hours, long minutes, long seconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes, seconds);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 0, 0)]
        [DataRow(0, -1, 0)]
        [DataRow(0, 0, -1)]
        [DataRow(-1, -1, 0)]
        [DataRow(-1, 0, -1)]
        [DataRow(0, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(23, 59, 60)]
        [DataRow(23, 60, 60)]
        [DataRow(24, 60, 60)]
        [DataRow(-1, 59, 59)]
        [DataRow(-1, 60, 59)]
        [DataRow(-1, 60, 60)]
        [DataRow(-1, -1, 60)]
        [DataRow(0, -1, 60)]
        [DataRow(-1, 0, 60)]
        [DataRow(-1, 60, 0)]
        [DataRow(24, -1, -1)]
        [DataRow(24, 0, -1)]
        [DataRow(24, -1, 0)]
        [DataRow(24, 60, 59)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThreeParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            long hours, long minutes, long seconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes, seconds);
        }

        #endregion ThreeParameters

        #region TwoParameters

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0, 0, 0)]
        [DataRow(8, 16, 8, 16, 0)]
        [DataRow(8, 59, 8, 59, 0)]
        [DataRow(23, 16, 23, 16, 0)]
        [DataRow(23, 59, 23, 59, 0)]
        [DataRow(0, 59, 0, 59, 0)]
        [DataRow(23, 0, 23, 0, 0)]
        public void ConstructorTwoParameters_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
            long hours, long minutes,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(1, 1, 1, 2, 0)]
        [DataRow(1, 1, 1, -1, 0)]
        [DataRow(1, 1, -1, -1, 0)]
        [DataRow(1, 1, 3, 5, 0)]
        [DataRow(1, 1, 23, 59, 0)]
        [DataRow(0, 0, 12, 12, 0)]
        [DataRow(10, 12, 0, 60, 0)]
        [DataRow(23, 59, 24, 60, 0)]
        public void ConstructorTwoParameters_WhenGivenCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            long hours, long minutes,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 1, -1, 1, 0)]
        [DataRow(1, -2, 1, -2, 0)]
        [DataRow(-1, -2, -1, -2, 0)]
        [DataRow(230, 60, 230, 60, 0)]
        [DataRow(23, 100, 23, 100, 0)]
        [DataRow(23, 50000, 23, 50000, 0)]
        [DataRow(24, 60, 24, 60, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTwoParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            long hours, long minutes,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(hours, minutes);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(-1, -1)]
        [DataRow(23, 60)]
        [DataRow(24, 60)]
        [DataRow(-1, 59)]
        [DataRow(-1, 60)]
        [DataRow(0, 60)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTwoParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            long hours, long minutes)
        {
            TimePeriod time = new TimePeriod(hours, minutes);
        }

        #endregion TwoParameters

        #region OneParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(5000, 1, 23, 20)]
        [DataRow(3599, 0, 59, 59)]
        [DataRow(848974, 235, 49, 34)]
        [DataRow(86400, 24, 0, 0)]
        [DataRow(86401, 24, 0, 1)]
        [DataRow(86399, 23, 59, 59)]
        public void ConstructorOneParameters_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
            long numberOfSeconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(numberOfSeconds);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(5000, 1, 23, 2)]
        [DataRow(3599, 0, 59, 9)]
        [DataRow(848974, 235, 9, 34)]
        [DataRow(86400, 24, 30, 0)]
        [DataRow(86401, 22, 0, 1)]
        [DataRow(86399, 231, 59, 59)]
        public void ConstructorOneParameters_WhenGivenCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            long numberOfSeconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(numberOfSeconds);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, -1, 0, 0)]
        [DataRow(-5000, -5000, 0, 0)]
        [DataRow(-84600, -84600, 0, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorOneParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            long numberOfSeconds,
            long expectedHours, long expectedMinutes, long expectedSeconds)
        {
            TimePeriod time = new TimePeriod(numberOfSeconds);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1)]
        [DataRow(-1423)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorOneParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            long numberOfSeconds)
        {
            TimePeriod time = new TimePeriod(numberOfSeconds);
        }

        #endregion OneParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0)]
        public void ConstructorDefault_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
        int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            TimePeriod time = new TimePeriod();
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        #region StringParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow("0:0:0", 0, 0, 0)]
        [DataRow("00:00:00", 0, 0, 0)]
        [DataRow("23:00:00", 23, 0, 0)]
        [DataRow("0:59:00", 0, 59, 0)]
        [DataRow("00:0:59", 0, 0, 59)]
        [DataRow("0:59:59", 0, 59, 59)]
        [DataRow("23:0:59", 23, 0, 59)]
        [DataRow("23:59:0", 23, 59, 0)]
        [DataRow("23:59:59", 23, 59, 59)]
        public void ConstructorString_WhenGivenCorrectParameter_ShouldReturnAreEqualsTrue(
            string pattern, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            TimePeriod time = new TimePeriod(pattern);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow("::")]
        [DataRow("0::")]
        [DataRow("0:0:")]
        [DataRow("0::0")]
        [DataRow(":0:00")]
        [DataRow("::00")]
        [DataRow(":00:")]
        [DataRow("")]
        [DataRow(":")]
        [DataRow(":::")]
        [DataRow(":::::")]
        [DataRow(":d:a:q:w:e")]
        [DataRow("0:1:1:2")]
        [DataRow("0:1:1:3:4:6")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorString_WhenGivenWrongFormatParameter_ShouldThrowArgumentOutOfRangeException(
            string pattern)
        {
            TimePeriod time = new TimePeriod(pattern);
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow("0:0:-1", 0, 0, -1)]
        [DataRow("0:-1:-1", 0, -1, -1)]
        [DataRow("-1:-1:-1", -1, -1, -1)]
        [DataRow("-1:1:-1", -1, 1, -1)]
        [DataRow("-1:-1:1", -1, -1, 1)]
        [DataRow("1:-1:1", 1, -1, 1)]
        [DataRow("24:-1:1", 24, -1, 1)]
        [DataRow("24:1:-1", 24, 1, -11)]
        [DataRow("0:60:-1", 0, 60, -1)]
        [DataRow("0:60:0", 0, 60, 60)]
        [DataRow("0:60:60", 0, 60, 60)]
        [DataRow("24:60:60", 24, 60, 60)]
        [DataRow("-1:60:50", -1, 60, 50)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorString_WhenGivenCorrectParameterButWrongNumberInTime_ArgumentOutOfRangeException(
            string pattern, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            TimePeriod time = new TimePeriod(pattern);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow("13:dwadwa:50", 13, 22, 50)]
        [DataRow("13:d:50", 13, 22, 50)]
        [DataRow("s:d:50", 13, 22, 50)]
        [DataRow("13:d:a", 13, 22, 50)]
        [DataRow("13:22:a", 13, 22, 50)]
        [DataRow(" :22:a", 13, 22, 50)]
        [DataRow(" : : ", 13, 22, 50)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorString_WhenGivenCorrectFormatButWrongParameters_ArgumentOutOfRangeException(
            string pattern, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            TimePeriod time = new TimePeriod(pattern);
            Assert.AreEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        #endregion StringParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(new int[] { 15, 10, 0 }, new int[] { 8, 45, 30 }, new int[] { 6, 24, 30 })]
        [DataRow(new int[] { 0, 0, 0 }, new int[] { 23, 59, 59 }, new int[] { 23, 59, 59 })]
        [DataRow(new int[] { 0, 0, 1 }, new int[] { 23, 59, 59 }, new int[] { 23, 59, 58 })]
        [DataRow(new int[] { 23, 59, 59 }, new int[] { 0, 0, 0 }, new int[] { 23, 59, 59 })]
        public void ConstructorTwoTime_WhenGivenCorrectTwoTimeParameters_ShouldReturnTimePeriodBetweenTimes(
            int[] time1, int[] time2, int[] time3)
        {
            Time t1 = new Time((byte)time1[0], (byte)time1[1], (byte)time1[2]);
            Time t2 = new Time((byte)time2[0], (byte)time2[1], (byte)time2[2]);
            TimePeriod t3 = new TimePeriod(t1, t2);
            TimePeriod t4 = new TimePeriod(time3[0], time3[1], time3[2]);
            Assert.IsTrue(t3 == t4);
        }
    }
}