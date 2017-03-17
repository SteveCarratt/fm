using System.Collections.Generic;
using Microsoft.Win32;

namespace FM
{
    public enum Mentality
    {
        Defend,
        Support,
        Attack
    }

    public static class PositionCoefficients
    {
        public static Dictionary<Mentality, PositionCoefficient> Midfielder
        {
            get
            {
                var mentalities = new Dictionary<Mentality, PositionCoefficient>();
                var attributeCoefficient = new AttributeCoefficient() {Minimum = 10, Maximum = 15};

                var coefficient = new PositionCoefficient()
                {
                    {PlayerAttribute.FirstTouch, attributeCoefficient},
                    {PlayerAttribute.Passing, attributeCoefficient},
                    {PlayerAttribute.Concentration, attributeCoefficient},
                    {PlayerAttribute.Decisions, attributeCoefficient},
                    {PlayerAttribute.Determination, attributeCoefficient},
                    {PlayerAttribute.Teamwork, attributeCoefficient},
                    {PlayerAttribute.WorkRate, attributeCoefficient},
                    {PlayerAttribute.Stamina, attributeCoefficient},
                };


                mentalities[Mentality.Defend] = new PositionCoefficient(coefficient)
                {
                    {PlayerAttribute.Heading, attributeCoefficient},
                    {PlayerAttribute.Marking, attributeCoefficient},
                    {PlayerAttribute.Tackling, attributeCoefficient},
                    {PlayerAttribute.Postioning, attributeCoefficient},
                };

                mentalities[Mentality.Support] = new PositionCoefficient(coefficient)
                {
                    {PlayerAttribute.Marking, attributeCoefficient},
                    {PlayerAttribute.Tackling, attributeCoefficient},
                    {PlayerAttribute.Postioning, attributeCoefficient},
                    {PlayerAttribute.OffTheBall, attributeCoefficient},
                };

                mentalities[Mentality.Attack] = new PositionCoefficient(coefficient)
                {
                    {PlayerAttribute.Finishing, attributeCoefficient},
                    {PlayerAttribute.LongThrows, attributeCoefficient},
                    {PlayerAttribute.Acceleration, attributeCoefficient},
                    {PlayerAttribute.OffTheBall, attributeCoefficient},
                };

                return mentalities;
            }
        }
    }

    public class PositionCoefficient : Dictionary<PlayerAttribute, AttributeCoefficient>
    {
        public PositionCoefficient() : base()
        {
        }

        public PositionCoefficient(PositionCoefficient coefficient) : base(coefficient)
        {
        }
    }

    public class AttributeCoefficient
    {
        public int Power { get; set; } = 1;
        public int Minimum { get; set; } = 0;
        public int Maximum { get; set; } = 20;
    }
}