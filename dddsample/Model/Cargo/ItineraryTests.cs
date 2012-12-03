using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class ItineraryTests
    {
        [Test]
        public void ItineraryWithSamePropertiesShouldBeSame()
        {
            var twoLegsStub = TwoLegsStub();
            var itinerary = new Itinerary(twoLegsStub);
            var expectedItinerary = new Itinerary(twoLegsStub);

            Assert.AreEqual(expectedItinerary, itinerary);
            Assert.AreEqual(twoLegsStub, itinerary.Legs);
        }

        [Test]
        public void ItineraryWithDifferentSequenceOfLegsShouldNotBeEqual()
        {
            var leg1 = new Leg(Location.Location.HongKong, 
                               Location.Location.LongBeach, 
                               new DateTime(2012, 11, 9), 
                               new DateTime(2012, 11, 12));
            var leg2 = new Leg(Location.Location.LongBeach, 
                               Location.Location.Dallas, 
                               new DateTime(2012, 11, 13), 
                               new DateTime(2012, 11, 15));
            var legs = new List<Leg> { leg1, leg2 };
            var legsWithDifferentSequence = new List<Leg> { leg2, leg1 };

            Assert.AreNotEqual(new Itinerary(legsWithDifferentSequence), new Itinerary(legs));
        }

        [Test]
        public void ItineraryShouldNotBeAbleToModifyLegs()
        {
            var twoLegsStub = TwoLegsStub();
            var itinerary = new Itinerary(twoLegsStub);
            twoLegsStub.AddRange(twoLegsStub);

            var expectedTwoLegsStub = TwoLegsStub();
            Assert.AreEqual(expectedTwoLegsStub, itinerary.Legs);
        }

        private static List<Leg> TwoLegsStub()
        {
            var leg1 = new Leg(Location.Location.HongKong,
                               Location.Location.LongBeach,
                               new DateTime(2012, 11, 9),
                               new DateTime(2012, 11, 12));
            var leg2 = new Leg(Location.Location.LongBeach,
                               Location.Location.Dallas,
                               new DateTime(2012, 11, 13),
                               new DateTime(2012, 11, 15));
            return new List<Leg> { leg1, leg2 };
        }

    }
}