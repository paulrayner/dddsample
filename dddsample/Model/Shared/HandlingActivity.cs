using System;

namespace dddsample.Model.Shared
{
    public class HandlingActivity : IEquatable<HandlingActivity>
    {
        public HandlingActivityType Type { get; private set; }
        public Location.Location Location { get; private set; }
        public Voyage.Voyage Voyage { get; private set; }

        public HandlingActivity(HandlingActivityType type, Location.Location location) : this (type, location, null) {}

        private HandlingActivity(HandlingActivityType type, Location.Location location, Voyage.Voyage voyage)
        {
            Type = type;
            Location = location;
            Voyage = voyage;
        }

        public static HandlingActivity ClaimIn(Location.Location location)
        {
            return new HandlingActivity(HandlingActivityType.Claim, location);
        }

        public static HandlingActivity ReceiveIn(Location.Location location)
        {
            return new HandlingActivity(HandlingActivityType.Receive, location);
        }

        public static HandlingActivity LoadOnto(Voyage.Voyage voyage, Location.Location location)
        {
            return new HandlingActivity(HandlingActivityType.Load, location, voyage);
        }

        public bool Equals(HandlingActivity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Location, Location) && Equals(other.Voyage, Voyage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (HandlingActivity)) return false;
            return Equals((HandlingActivity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Type.GetHashCode();
                result = (result*397) ^ (Location != null ? Location.GetHashCode() : 0);
                result = (result*397) ^ (Voyage != null ? Voyage.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(HandlingActivity left, HandlingActivity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HandlingActivity left, HandlingActivity right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Location: {1}, Voyage: {2}", Type, Location, Voyage);
        }
    }
}