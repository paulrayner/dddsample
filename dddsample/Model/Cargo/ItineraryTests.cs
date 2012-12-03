using System;
using System.Collections.Generic;
using NUnit.Framework;
using dddsample.Model.Shared;

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