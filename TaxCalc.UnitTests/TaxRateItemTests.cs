using System;
using Xunit;

namespace TaxCalc.UnitTests
{
    public class TaxRateItemTests
    {
        [Fact]
        public void WhenThresholdIsLessThenZero_ArgumentExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => new TaxRateItem(-1, 10));
        }

        [Fact]
        public void WhenRateIsLessThenZero_ArgumentExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => new TaxRateItem(10000, -1));
        }

        [Fact]
        public void WhenRateIsMoreThanOneHounded_ArgumentExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => new TaxRateItem(10000, 101));
        }

        [Fact]
        public void WhenValidArgumentPassed_NoException()
        {
            var exception = Record.Exception(() => new TaxRateItem(10000, 10));
            Assert.Null(exception);
        }
    }
}
