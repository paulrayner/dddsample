﻿using NUnit.Framework;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class TrackingIdTests
    {
        [Test]
        public void TrackingIdShouldBeValueObject()
        {
            var trackingId = new TrackingId("XYZ");

            Assert.AreEqual(new TrackingId("XYZ"), trackingId);
            Assert.AreNotEqual(new TrackingId("ABC"), trackingId);
        }
    }
}