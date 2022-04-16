using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests.TimeTests
{
    [TestClass]
    public class TimeConstructorTests
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
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Assert.AreNotEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 1, 1, -1, 1, 1)]
        [DataRow(1, -2, 1, 1, -2, 1)]
        [DataRow(0, 0, -1, 0, 0, -1)]
        [DataRow(230, 10, 60, 230, 10, 60)]
        [DataRow(24, 59, 59, 24, 59, 59)]
        [DataRow(23, 100, 59, 23, 100, 59)]
        [DataRow(23, 100, 10, 23, 100, 10)]
        [DataRow(23, 100, 50000, 23, 100, 50000)]
        [DataRow(24, 10, 100, 24, 10, 100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThreeParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Assert.AreNotEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
        [DataRow(24, 0, 0)]
        [DataRow(24, -1, -1)]
        [DataRow(24, 0, -1)]
        [DataRow(24, -1, 0)]
        [DataRow(24, 59, 59)]
        [DataRow(24, 60, 59)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThreeParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes, int seconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
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
            int hours, int minutes,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
            int hours, int minutes,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes);
            Assert.AreNotEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 1, -1, 1, 0)]
        [DataRow(1, -2, 1, -2, 0)]
        [DataRow(-1, -2, -1, -2, 0)]
        [DataRow(230, 10, 230, 10, 0)]
        [DataRow(230, 60, 230, 60, 0)]
        [DataRow(24, 59, 24, 59, 0)]
        [DataRow(23, 100, 23, 100, 0)]
        [DataRow(23, 50000, 23, 50000, 0)]
        [DataRow(24, 60, 24, 60, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTwoParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes);
            Assert.AreNotEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(-1, -1)]
        [DataRow(23, 60)]
        [DataRow(24, 59)]
        [DataRow(24, 60)]
        [DataRow(-1, 59)]
        [DataRow(-1, 60)]
        [DataRow(0, 60)]
        [DataRow(24, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTwoParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes)
        {
            Time time = new Time((byte)hours, (byte)minutes);
        }

        #endregion TwoParameters

        #region OneParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0, 0)]
        [DataRow(16, 16, 0, 0)]
        [DataRow(1, 1, 0, 0)]
        [DataRow(23, 23, 0, 0)]
        [DataRow(23, 23, 0, 0)]
        public void ConstructorOneParameters_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
            int hours,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, -1, 0, 0)]
        [DataRow(1, -500, 0, 0)]
        [DataRow(12, -1, 0, 0)]
        [DataRow(23, 59, 0, 0)]
        public void ConstructorOneParameters_WhenGivenCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            int hours,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours);
            Assert.AreNotEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, -1, 0, 0)]
        [DataRow(-5000, -5000, 0, 0)]
        [DataRow(501, 300, 0, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorOneParameters_WhenGivenWrongParametersAndExpectedSameParameters_ShouldThrowArgumentOutOfRangeException(
            int hours,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours);
            Assert.AreNotEqual(
                (expectedHours, expectedMinutes, expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1)]
        [DataRow(-1423)]
        [DataRow(24)]
        [DataRow(2400)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorOneParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            int hours)
        {
            Time time = new Time((byte)hours);
        }

        #endregion OneParameter

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0)]
        public void ConstructorDefault_WhenGivenCorrectParameters_ShouldReturnAreEqualsTrue(
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time();
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
            Time time = new Time(pattern);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
            Time time = new Time(pattern);
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow("0:0:-1", 0, 0, -1)]
        [DataRow("0:-1:-1", 0, -1, -1)]
        [DataRow("-1:-1:-1", -1, -1, -1)]
        [DataRow("-1:1:-1", -1, 1, -1)]
        [DataRow("-1:-1:1", -1, -1, 1)]
        [DataRow("1:-1:1", 1, -1, 1)]
        [DataRow("24:-1:1", 24, -1, 1)]
        [DataRow("24:1:1", 24, 1, 1)]
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
            Time time = new Time(pattern);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
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
            Time time = new Time(pattern);
            Assert.AreEqual(
                ((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds),
                (time.Hours, time.Minutes, time.Seconds));
        }

        #endregion StringParameter
    }
}