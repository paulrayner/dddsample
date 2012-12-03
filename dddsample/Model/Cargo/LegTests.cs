using System;
using System.Collections.Generic;
using NUnit.Framework;
using dddsample.Model.Shared;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class LegTests
    {
        [Test]
        public void LegShouldBeValueObject()
        {
            var leg = new Leg(Location.Location.HongKong, Location.Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var expectedLeg = new Leg(Location.Location.HongKong, Location.Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var differentLeg = new Leg(Location.Location.HongKong, Location.Location.Dallas, new DateTime(2012, 11, 10), new DateTime(2012, 11, 12));

            Assert.AreEqual(expectedLeg, leg);
            Assert.AreNotEqual(differentLeg, leg);
        }
    }
}