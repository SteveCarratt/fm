using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Timers;
using FM;
using ImageProcessor;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Recognition.Tests
{
    [TestFixture]
    public class RecogniseTest
    {
        private AttributesImage _attributesImage;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Recognise.TessdataDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "tessdata");
            _attributesImage =
                new AttributesImage(Path.Combine(TestContext.CurrentContext.TestDirectory, @"data\malyon.png"));
        }

        [TestCase(PlayerAttribute.Corners, 11)]
        [TestCase(PlayerAttribute.Crossing, 8)]
        [TestCase(PlayerAttribute.Dribbling, 9)]
        [TestCase(PlayerAttribute.Finishing, 14)]
        [TestCase(PlayerAttribute.FirstTouch, 8)]
        [TestCase(PlayerAttribute.FreeKickTaking, 11)]
        [TestCase(PlayerAttribute.Heading, 16)]
        [TestCase(PlayerAttribute.LongShots, 9)]
        [TestCase(PlayerAttribute.LongThrows, 4)]
        [TestCase(PlayerAttribute.Marking, 11)]
        [TestCase(PlayerAttribute.Passing, 9)]
        [TestCase(PlayerAttribute.PenaltyTaking, 7)]
        [TestCase(PlayerAttribute.Tackling, 11)]
        [TestCase(PlayerAttribute.Technique, 12)]
        [TestCase(PlayerAttribute.Agression, 8)]
        [TestCase(PlayerAttribute.Anticipation, 9)]
        [TestCase(PlayerAttribute.Bravery, 12)]
        [TestCase(PlayerAttribute.Composure, 9)]
        [TestCase(PlayerAttribute.Concentration, 16)]
        [TestCase(PlayerAttribute.Decisions, 11)]
        [TestCase(PlayerAttribute.Determination, 17)]
        [TestCase(PlayerAttribute.Flair, 8)]
        [TestCase(PlayerAttribute.Leadership, 10)]
        [TestCase(PlayerAttribute.OffTheBall, 12)]
        [TestCase(PlayerAttribute.Postioning, 10)]
        [TestCase(PlayerAttribute.Teamwork, 14)]
        [TestCase(PlayerAttribute.Vision, 9)]
        [TestCase(PlayerAttribute.WorkRate, 16)]
        [TestCase(PlayerAttribute.Acceleration, 14)]
        [TestCase(PlayerAttribute.Agility, 10)]
        [TestCase(PlayerAttribute.Balance, 10)]
        [TestCase(PlayerAttribute.JumpingReach, 16)]
        [TestCase(PlayerAttribute.NaturalFitness, 14)]
        [TestCase(PlayerAttribute.Pace, 12)]
        [TestCase(PlayerAttribute.Stamina, 16)]
        [TestCase(PlayerAttribute.Strength, 17)]
        public void Recognises_attribute(PlayerAttribute attribute, int expectedValue)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var readValue = _attributesImage.GetValueForAttribute(attribute);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            Assert.That(readValue, Is.EqualTo(expectedValue));

        }
    }
}