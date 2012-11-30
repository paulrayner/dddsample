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
            TransportStatus = TransportStatus.DeriveTransportStatus(handlingActivity);
            LastKnownLocation = handlingActivity.Location;
        }

        public void AssignToRoute(Itinerary itinerary)
        {
            Itinerary = itinerary;
            RoutingStatus = RoutingStatus.Routed;
        }
    }
}