using dddsample.Models;

namespace dddsample
{
    public class Cargo
    {
        public RoutingStatus RoutingStatus  { get; private set; }
        public RouteSpecification RouteSpecification { get; private set; }
        public TransportStatus TransportStatus { get; private set; }
        public Location LastKnownLocation { get; private set; }
        public Itinerary Itinerary { get; private set; }
        public TrackingId TrackingId { get; private set; }

        public Cargo(TrackingId trackingId, RouteSpecification routeSpecification)
        {
            TrackingId = trackingId;
            RouteSpecification = routeSpecification;
            TransportStatus = TransportStatus.NotReceived;
            RoutingStatus = RoutingStatus.NotRouted;
        }

        public void Handled(HandlingActivity handlingActivity)
        {
            if (handlingActivity.Equals(HandlingActivity.ReceiveIn(new Location("HONG KONG"))))
            {
                TransportStatus = TransportStatus.InPort;
            }
            else if (handlingActivity.Equals(HandlingActivity.ClaimIn(new Location("USDAL"))))
            {
                TransportStatus = TransportStatus.Claimed;
            }
            else
            {
                TransportStatus = TransportStatus.OnboardCarrier;
            }
            LastKnownLocation = handlingActivity.Location;
        }

        public void AssignToRoute(Itinerary itinerary)
        {
            Itinerary = itinerary;
            RoutingStatus = RoutingStatus.Routed;
        }
    }
}