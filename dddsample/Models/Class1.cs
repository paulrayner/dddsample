using NUnit.Framework;

namespace dddsample
{
    [TestFixture]
    public class CargoLifecycle
    {
        [Test]
        public void CargoIsProperlyDelivered()
        {
            Cargo cargo = SetupCargoFromHongkongToDallas();
            Assert.AreEqual(true, true);
        }

        private Cargo SetupCargoFromHongkongToDallas()
        {
            // TODO: add logic to get trackingId, arrivalDeadline and routeSpecification
            return new Cargo();
        }
    }
}
