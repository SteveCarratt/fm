using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FM
{
    public static class Rating
    {
        public static double Calculate(PositionCoefficient coefficient, PlayerAttributes playerAttributes)
        {
            double rating = 0;
            double minRating = 1;
            int count = 0;
            
            foreach (var coeff in coefficient)
            {
                var maxRating = GetMaxRating(coeff.Value.Maximum, playerAttributes[coeff.Key]);
                minRating = minRating*GetMinRating(coeff.Value.Minimum, playerAttributes[coeff.Key]);
                var standardRating = GetStandardRating(coeff.Value.Power, playerAttributes[coeff.Key]);
                count += coeff.Value.Power;
                rating += standardRating;
            }

            return (rating*minRating) / count;
        }

        private static double GetMinRating(int min, int attributeValue)
        {
            return 1d/(1d + Math.Pow(Math.E, (min - attributeValue-0.5)*20));
        }

        private static double GetMaxRating(int max, int attributeValue)
        {
            return ((attributeValue - GetMinRating(max, attributeValue)*attributeValue) +
                   GetMinRating(max, attributeValue)*max)/20;
        }

        private static double GetStandardRating(int power, int value)
        {
            return Convert.ToDouble(value)* power/20d;
        }
    }
}
