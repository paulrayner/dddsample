using System;
using dddsample.Model.Shared;

namespace dddsample.Model.Cargo
{
    public class Delivery : IEquatable<Delivery>
    {
        public HandlingActivity MostRecentHandlingActivity { get; private set; }
        public DateTime LastUpdatedOn { get; private set; }

        private Delivery(HandlingActivity mostRecentHandlingActivity)
        {
            MostRecentHandlingActivity = mostRecentHandlingActivity;
            LastUpdatedOn = SystemTime.Now();
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

        public bool Equals(Delivery other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.MostRecentHandlingActivity, MostRecentHandlingActivity) && other.LastUpdatedOn.Equals(LastUpdatedOn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Delivery)) return false;
            return Equals((Delivery) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((MostRecentHandlingActivity != null ? MostRecentHandlingActivity.GetHashCode() : 0)*397) ^ LastUpdatedOn.GetHashCode();
            }
        }

        public static bool operator ==(Delivery left, Delivery right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Delivery left, Delivery right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("MostRecentHandlingActivity: {0}, LastUpdatedOn: {1}", MostRecentHandlingActivity, LastUpdatedOn);
        }
    }
}