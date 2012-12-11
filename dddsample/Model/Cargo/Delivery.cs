using dddsample.Model.Shared;

namespace dddsample.Model.Cargo
{
    public class Delivery
    {
        public HandlingActivity MostRecentHandlingActivity { get; private set; }

        private Delivery(HandlingActivity mostRecentHandlingActivity)
        {
            MostRecentHandlingActivity = mostRecentHandlingActivity;
        }

        public static Delivery BeforeHandling()
        {
            return new Delivery(null);
        }

        public Delivery OnHandling(HandlingActivity handlingActivity)
        {
            MostRecentHandlingActivity = handlingActivity;
            return new Delivery(MostRecentHandlingActivity);
        }

        public Location.Location LastKnownLocation
        {
            get { return MostRecentHandlingActivity.Location; }
        }

        public Voyage.Voyage CurrentVoyage
        {
            get {
                return HasBeenHandled() && TransportStatus == TransportStatus.OnboardCarrier
                           ? MostRecentHandlingActivity.Voyage
                           : Voyage.Voyage.None;
            }
        }

        private bool HasBeenHandled()
        {
            return (MostRecentHandlingActivity != null);
        }

        public TransportStatus TransportStatus
        {
            get { return TransportStatus.OnboardCarrier.DeriveTransportStatus(MostRecentHandlingActivity); } // TODO Fix syntax for extension method - this is weird!
        }
    }
}