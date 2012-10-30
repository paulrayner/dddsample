namespace dddsample
{
    public class Cargo
    {
        public RoutingStatus RoutingStatus  { get; private set; }
        public RouteSpecification RouteSpecification { get; private set; }

        public TransportStatus TransportStatus { get; set; }

        public Cargo(RouteSpecification routeSpecification)
        {
            TransportStatus = TransportStatus.NotReceived;
            RoutingStatus = RoutingStatus.NotRouted;
            RouteSpecification = routeSpecification;
        }

        public void Handled(HandlingActivity handlingActivity)
        {
            TransportStatus = TransportStatus.Claimed;
        }

        public void AssignToRoute(Itinerary itinerary)
        {
            RoutingStatus = RoutingStatus.Routed;
        }
    }
}