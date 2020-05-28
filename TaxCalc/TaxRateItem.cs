using System;

namespace TaxCalc
{
    public class TaxRateItem
    {
        public TaxRateItem(double? threshold, int rate)
        {
            if (threshold < 0)
                throw new ArgumentException($"{nameof(threshold)} has to be greater or equal zero.");
            if (rate < 0 || rate > 100)
                throw new ArgumentException($"{nameof(rate)} has to be value between 0 and 100");

            Threshold = threshold;
            Rate = rate;
        }

        public double? Threshold { get; }
        public int Rate { get; }

        public static double? LastThreshold => null;
    }
}