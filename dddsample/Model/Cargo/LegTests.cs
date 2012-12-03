using System;
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
            var legWithDifferentUnloadDate = new Leg(Location.Location.HongKong, 
                              Location.Location.LongBeach, 
                              new DateTime(2012, 11, 9), 
                              new DateTime(2012, 11, 13));

            Assert.AreNotEqual(legWithDifferentLoadDate, leg);
            Assert.AreNotEqual(legWithDifferentUnloadDate, leg);
        }

        [Test]
        public void LegsWithDifferentLocationsShouldNotBeEqual()
        {
            var leg = new Leg(Location.Location.HongKong,
                  Location.Location.LongBeach,
                  new DateTime(2012, 11, 9),
                  new DateTime(2012, 11, 12));

            var legWithDifferentLoadLocation = new Leg(Location.Location.Singapore,
                              Location.Location.LongBeach,
                              new DateTime(2012, 11, 9),
                              new DateTime(2012, 11, 12));
            var legWithDifferentUnloadLocation = new Leg(Location.Location.HongKong,
                              Location.Location.Singapore,
                              new DateTime(2012, 11, 9),
                              new DateTime(2012, 11, 12));

            Assert.AreNotEqual(legWithDifferentLoadLocation, leg);
            Assert.AreNotEqual(legWithDifferentUnloadLocation, leg);
        }
    }
}