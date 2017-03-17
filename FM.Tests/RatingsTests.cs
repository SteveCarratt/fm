using NUnit.Framework;

namespace FM.Tests
{
    [TestFixture]
    public class RatingsTests
    {
        [TestCase(20,1)]
        [TestCase(10,0.5)]
        [TestCase(0,0)]
        public void Calculates_rating_for_one_attr(int value, double expected)
        {
            var attr = new WritablePlayerAttributes();
            attr[PlayerAttribute.Acceleration] = value;
            var coeff = new PositionCoefficient();
            coeff[PlayerAttribute.Acceleration] =  new AttributeCoefficient();

            var rating = Rating.Calculate(coeff, attr);

            Assert.That(rating, Is.EqualTo(expected).Within(0.001));
        }

        [TestCase(20, 20, 1)]
        [TestCase(10, 10, 0.5)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 20, 0.5)]
        [TestCase(10, 15, 0.625)]
        public void Calculates_rating_for_two_attr_with_same_power(int value1, int value2, double expected)
        {
            var attr = new WritablePlayerAttributes();
            attr[PlayerAttribute.Acceleration] = value1;
            attr[PlayerAttribute.Agility] = value2;
            var coeff = new PositionCoefficient();
            coeff[PlayerAttribute.Acceleration] = new AttributeCoefficient();
            coeff[PlayerAttribute.Agility] = new AttributeCoefficient();

            var rating = Rating.Calculate(coeff, attr);

            Assert.That(rating, Is.EqualTo(expected).Within(0.001));
        }

        [TestCase(20, 20, 1)]
        [TestCase(10, 10, 0.5)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 20, 0.3333)]
        [TestCase(10, 15, 0.5833)]
        public void Calculates_rating_for_two_attr_with_different_power(int value1, int value2, double expected)
        {
            var attr = new WritablePlayerAttributes();
            attr[PlayerAttribute.Acceleration] = value1;
            attr[PlayerAttribute.Agility] = value2;
            var coeff = new PositionCoefficient();
            coeff[PlayerAttribute.Acceleration] = new AttributeCoefficient() { Power = 2 };
            coeff[PlayerAttribute.Agility] = new AttributeCoefficient();

            var rating = Rating.Calculate(coeff, attr);

            Assert.That(rating, Is.EqualTo(expected).Within(0.0003));
        }

        [TestCase(20, 20, 1)]
        [TestCase(10, 10, 0.5)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 20, 0)]
        [TestCase(9, 15, 0)]
        public void Calculates_rating_for_two_attr_with_different_min(int value1, int value2, double expected)
        {
            var attr = new WritablePlayerAttributes();
            attr[PlayerAttribute.Acceleration] = value1;
            attr[PlayerAttribute.Agility] = value2;
            var coeff = new PositionCoefficient();
            coeff[PlayerAttribute.Acceleration] = new AttributeCoefficient() { Minimum = 10 };
            coeff[PlayerAttribute.Agility] = new AttributeCoefficient();

            var rating = Rating.Calculate(coeff, attr);

            Assert.That(rating, Is.EqualTo(expected).Within(0.0003));
        }
    }
}
