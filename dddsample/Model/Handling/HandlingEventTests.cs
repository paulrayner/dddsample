using System;
using System.Collections.Generic;
using NUnit.Framework;
using dddsample.Model.Cargo;
using dddsample.Model.Shared;
using dddsample.Model.Voyage;

namespace dddsample.Model.Handling
{
    [TestFixture]
    public class HandlingEventTests
    {
        [Test]
        public void HandlingEventWithSamePropertiesShouldBeSame()
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
            Assert.AreEqual(handlingEvent2, handlingEvent1);
        }

        // TODO Add tests for inequality
    }
}