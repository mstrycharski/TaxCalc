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

            //double calculatedTax = 0;
            double alreadyTaxedIncome = 0;

            return taxRate.TaxRateItems.Aggregate(0.0, (alreadyCalculatedTax, currentTaxRate) =>
            {
                if (alreadyTaxedIncome >= income)
                    return alreadyCalculatedTax;

                var amountOfMoneyForCurrentTaxRate = (currentTaxRate.Threshold ?? income) - alreadyTaxedIncome;

                var amountOfMoneyToBeTaxedByCurrentRate =
                    Math.Min(amountOfMoneyForCurrentTaxRate, income - alreadyTaxedIncome);

                alreadyTaxedIncome += amountOfMoneyToBeTaxedByCurrentRate;
                alreadyCalculatedTax += amountOfMoneyToBeTaxedByCurrentRate * currentTaxRate.Rate / 100;

                return alreadyCalculatedTax;
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
