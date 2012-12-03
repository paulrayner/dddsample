using System;
using System.Collections.Generic;
using NUnit.Framework;
using dddsample.Model.Location;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class ItineraryTests
    {
        [Test]
        public void ItineraryShouldBeValueObject()
        {
            var itinerary = StubItinerary();
            var expectedItinerary = StubItinerary();

            Assert.AreEqual(expectedItinerary, itinerary);
        }


        [Test]
        public void ItineraryEqualitySequenceOfLegsMatters()
        {
            var leg1 = new Leg(Location.Location.HongKong, Location.Location.LongBeach, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var leg2 = new Leg(Location.Location.LongBeach, Location.Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs1 = new List<Leg> { leg1, leg2 };
            var legs2 = new List<Leg> { leg2, leg1 };

            Assert.AreNotEqual(new Itinerary(legs1), new Itinerary(legs2));

        }

        private static Itinerary StubItinerary()
        {
            return new Itinerary(GetStubLegs());
        }

        private static List<Leg> GetStubLegs()
        {
            var leg = new Leg(Location.Location.HongKong, Location.Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs = new List<Leg> {leg};
            return legs;
        }

    }
}