using System;
using NUnit.Framework;
using dddsample.Model.Cargo;
using dddsample.Model.Shared;
using dddsample.Model.Voyage;

namespace dddsample.Model.Handling
{
    [TestFixture]
    public class HandlingHistoryTests
    {
        // TODO Yuck! Clearly I don't yet understand how this should be used...
        [Test]
        public void HandlingHistoryWithSamePropertiesShouldBeSame()
        {
            DateTime now = DateTime.Now;
            var handlingEvent1 = new HandlingEvent(new TrackingId("CARGO_ABC123"),
                                                   now,
                                                   now,
                                                   HandlingActivityType.Load,
                                                   Location.Location.HongKong,
                                                   new VoyageNumber("ABC"),
                                                   new OperatorCode("PAUL RAYNER"));

            var handlingEvent2 = new HandlingEvent(new TrackingId("CARGO_ABC123"),
                                                   now,
                                                   now,
                                                   HandlingActivityType.Load,
                                                   Location.Location.HongKong,
                                                   new VoyageNumber("ABC"),
                                                   new OperatorCode("PAUL RAYNER"));

        }
    }
}