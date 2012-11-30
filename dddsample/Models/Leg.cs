using System;

namespace dddsample
{
    public class Leg : IEquatable<Leg>
    {
        public Location LoadLocation { get; private set; }
        public Location UnLoadLocation { get; private set; }
        public DateTime LoadTime { get; private set; }
        public DateTime UnLoadTime { get; private set; }

        public Leg(Location loadLocation, Location unLoadLocation, DateTime loadTime, DateTime unLoadTime)
        {
            LoadLocation = loadLocation;
            UnLoadLocation = unLoadLocation;
            LoadTime = loadTime;
            UnLoadTime = unLoadTime;
        }

        public bool Equals(Leg other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.LoadLocation, LoadLocation) && Equals(other.UnLoadLocation, UnLoadLocation) && other.LoadTime.Equals(LoadTime) && other.UnLoadTime.Equals(UnLoadTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Leg)) return false;
            return Equals((Leg) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = LoadLocation.GetHashCode();
                result = (result*397) ^ UnLoadLocation.GetHashCode();
                result = (result*397) ^ LoadTime.GetHashCode();
                result = (result*397) ^ UnLoadTime.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(Leg left, Leg right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Leg left, Leg right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("LoadLocation: {0}, UnLoadLocation: {1}, LoadTime: {2}, UnLoadTime: {3}", LoadLocation, UnLoadLocation, LoadTime, UnLoadTime);
        }
    }
}