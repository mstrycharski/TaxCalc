using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalc.Extensions;

namespace TaxCalc
{
    public class TaxRate
    {
        public TaxRate(params TaxRateItem[] taxRateItems)
        {
            if (taxRateItems == null)
                throw new ArgumentNullException("taxRateItems");

            if (taxRateItems.Select(x => x.Threshold).HasDuplicate())
            {
                throw new ArgumentException($"{nameof(taxRateItems)} contains duplicates");
            }

            TaxRateItems = taxRateItems.ToList().AsReadOnly();
        }

        public IReadOnlyCollection<TaxRateItem> TaxRateItems { get; }
    }
}