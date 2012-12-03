using System;
using dddsample.Model.Location;
using NUnit.Framework;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class LegTests
    {
        [Test]
        public void LegWithSamePropertiesShouldBeSame()
        {
            var leg = new Leg(Location.Location.HongKong, 
                              Location.Location.LongBeach, 
                              new DateTime(2012, 11, 9), 
                              new DateTime(2012, 11, 12));
            var expectedLeg = new Leg(Location.Location.HongKong,
                              Location.Location.LongBeach,
                              new DateTime(2012, 11, 9),
                              new DateTime(2012, 11, 12));

            Assert.AreEqual(expectedLeg, leg);
        }

        [Test]
        public void LegsWithDifferentDatesShouldNotBeEqual()
        {
            var leg = new Leg(Location.Location.HongKong, 
                              Location.Location.LongBeach, 
                              new DateTime(2012, 11, 9), 
                              new DateTime(2012, 11, 12));
            var legWithDifferentLoadDate = new Leg(Location.Location.HongKong, 
                              Location.Location.LongBeach, 
                              new DateTime(2012, 11, 10), 
                              new DateTime(2012, 11, 12));

            Assert.AreNotEqual(legWithDifferentLoadDate, leg);
        }

        [Test]
        public void LegsWithDifferentLocationsShouldNotBeEqual()
        {
        }
    }
}