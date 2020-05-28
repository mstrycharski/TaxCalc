using System;
using System.Linq;

namespace TaxCalc
{
    public class TaxCalc
    {
        public static double CalculateTax(double income, TaxRate taxRate)
        {
            if (taxRate == null || !taxRate.TaxRateItems.Any())
                throw new ArgumentNullException("taxRate");
            if (income < 0)
                throw new ArgumentException($"{nameof(income)} has to be greater than zero");

            double calculatedTax = 0;
            double alreadyTaxedIncome = 0;

            return taxRate.TaxRateItems.Aggregate(0.0, (x, y) =>
            {
                if (alreadyTaxedIncome >= income)
                    return x;

                var amountOfMoneyForCurrentTaxRate = (y.Threshold ?? income) - alreadyTaxedIncome;

                var amountOdMoneyToBeTaxedByCurrentRate =
                    Math.Min(amountOfMoneyForCurrentTaxRate, income - alreadyTaxedIncome);

                alreadyTaxedIncome += amountOfMoneyForCurrentTaxRate;
                x += amountOdMoneyToBeTaxedByCurrentRate * y.Rate / 100;

                return x;
            });

            //foreach (var taxRateItem in taxRate.TaxRateItems)
            //{
            //    if (alreadyTaxedIncome >= income)
            //        break;

            //    var amountOfMoneyForCurrentTaxRate = (taxRateItem.Threshold ?? income) - alreadyTaxedIncome;

            //    calculatedTax += Math.Min(amountOfMoneyForCurrentTaxRate, income - alreadyTaxedIncome) *
            //                     taxRateItem.Rate / 100;
            //    alreadyTaxedIncome += amountOfMoneyForCurrentTaxRate;
            //}

            //return calculatedTax;
        }
    }
}
