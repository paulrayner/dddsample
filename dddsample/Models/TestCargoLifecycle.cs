using NUnit.Framework;

namespace dddsample
{
    [TestFixture]
    public class CargoLifecycle
    {

        [Test]
        public void CargoIsProperlyDelivered()
        {
            var cargo = new Cargo();
            // TODO: Implement cargo.NextExpectedActivity()
            // TODO: Implement cargo.IsReadyToClaim()  <--- based on customs clearance point == destination

            // Test initial state of Cargo
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus());
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus());
            
            // Route the cargo

            cargo.Handled(HandlingActivity.ClaimIn(new Location("USDAL")));
            Assert.AreEqual(TransportStatus.Claimed, cargo.TransportStatus());

            //Assert.IsNull(cargo.NextExpectedActivity());
        }
    }
}
