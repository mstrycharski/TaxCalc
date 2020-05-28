using System;
using Xunit;

namespace TaxCalc.UnitTests
{
    public class TaxCalcTests
    {
        [Fact]
        public void WhenIncomeIsLessThenZero_ArgumentExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => TaxCalc.CalculateTax(-1,
                new TaxRate(new TaxRateItem(100, 10))));
        }

        [Fact]
        public void WhenTaxRateIsEmpty_ArgumentExceptionExpected()
        {

        }

        [Theory]
        [InlineData(9999, 0)]
        [InlineData(10000, 0)]
        [InlineData(10001, 0.1)]
        [InlineData(50000, 4000)]
        [InlineData(50001, 4000.3)]
        [InlineData(75000, 11500)]
        public void WhenTaxRateHasThreeThreshold_CalculatedTaxReturned(double income, double expectedTax)
        {
            Assert.Equal(expectedTax,
                TaxCalc.CalculateTax(income,
                    new TaxRate(new TaxRateItem(10000, 0),
                        new TaxRateItem(50000, 10),
                        new TaxRateItem(null, 30))));
        }

        [Theory]
        [InlineData(9999, 0)]
        [InlineData(10000, 0)]
        [InlineData(10001, 0.1)]
        [InlineData(50000, 4000)]
        [InlineData(50001, 4000.3)]
        [InlineData(75000, 11500)]
        public void WhenTaxRateAreNotSorted_CalculatedTaxReturned(double income, double expectedTax)
        {
            Assert.Equal(expectedTax,
                TaxCalc.CalculateTax(income,
                    new TaxRate(new TaxRateItem(null, 30),
                        new TaxRateItem(10000, 0),
                        new TaxRateItem(50000, 10))));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(100000)]
        public void WhenTaxRateIsAlwaysZero_ReturnsZero(int income)
        {
            Assert.Equal(0,
                TaxCalc.CalculateTax(income, new TaxRate(new TaxRateItem(null, 0))));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(100000)]
        public void WhenTaxRateIsAlwaysOneHundredPercentage_ReturnsEntireIncome(int income)
        {
            Assert.Equal(income,
                TaxCalc.CalculateTax(income,
                    new TaxRate(new TaxRateItem(null, 100))));
        }
    }
}
