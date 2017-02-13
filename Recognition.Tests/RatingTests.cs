using System;
using FM;
using NUnit.Framework;

namespace Recognition.Tests
{
    [TestFixture]
    public class RatingTests
    {
        [Test]
        public void Calculates_rating_correctly()
        {
            var attributes = new WritablePlayerAttributes();
            attributes[PlayerAttribute.Acceleration] = 20;
            attributes[PlayerAttribute.Agility] = 10;
            attributes[PlayerAttribute.Leadership] = 9;

            Console.WriteLine(Rating.Calculate(attributes));
        }
    }
}