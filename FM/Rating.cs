using System;

namespace FM
{
    public class Rating
    {
        public static double Calculate(PlayerAttributes playerAttributes)
        {
            //var minAccelerationRating = GetMinRating(10, PlayerAttributes["acceleration"]);
            //var minAgilityRating = GetMinRating(10, PlayerAttributes["agility"]);
            var maxLeadershipRating = GetMaxRating(10, playerAttributes[PlayerAttribute.Leadership]);
            return maxLeadershipRating; //Math.Pow((minAccelerationRating)*(minAgilityRating), 1d/2d);
        }

        private static double GetMinRating(int min, int attributeValue)
        {
            return 1d/(1d + Math.Pow(Math.E, (min - attributeValue)*13));
        }

        private static double GetMaxRating(int max, int attributeValue)
        {
            return ((attributeValue - GetMinRating(max, attributeValue)*attributeValue) +
                   GetMinRating(max, attributeValue)*max)/20;
        }
    }
}
