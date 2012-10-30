namespace dddsample
{
    public class Cargo
    {
        private TransportStatus _transportStatus = dddsample.TransportStatus.NotReceived;
        public RouteSpecification RouteSpecification { get; private set; }

        public Cargo(RouteSpecification routeSpecification)
        {
            RouteSpecification = routeSpecification;
        }

        public TransportStatus TransportStatus()
        {
            return _transportStatus;
        }

        public void Handled(HandlingActivity handlingActivity)
        {
            _transportStatus = dddsample.TransportStatus.Claimed;
        }

        public RoutingStatus RoutingStatus()
        {
            return dddsample.RoutingStatus.NotRouted;
        }
    }
}