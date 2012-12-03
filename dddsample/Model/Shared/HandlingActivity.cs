using System;

namespace dddsample.Model.Shared
{
    public class HandlingActivity : IEquatable<HandlingActivity>
    {
        public HandlingActivityType Type { get; private set; }
        public Location.Location Location { get; private set; }

        private HandlingActivity(HandlingActivityType type, Location.Location location)
        {
            Type = type;
            Location = location;
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
            return new HandlingActivity(HandlingActivityType.Load, location);
        }


        public bool Equals(HandlingActivity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Location, Location);
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
                return (Type.GetHashCode()*397) ^ Location.GetHashCode();
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
            return string.Format("Type: {0}, Location: {1}", Type, Location);
        }
    }
}