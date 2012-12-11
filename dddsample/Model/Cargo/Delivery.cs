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
            get { return MostRecentHandlingActivity.Voyage; }
        }
    }
}