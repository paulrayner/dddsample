using System;

namespace dddsample.Model.Location
{
    public class Location : IEquatable<Location>
    {
        public readonly UnLocode UnLocode;

        // Java example requires client of Location having to specify timezone etc - should just
        // be able to pass in the United Nations location locationCode
        public static Location HongKong = new Location("HONG KONG");
        public static Location LongBeach = new Location("USLGB");
        public static Location Dallas = new Location("USDAL");

        public Location(string locationCode)
        {
            UnLocode = new UnLocode(locationCode);
        }

        public override string ToString()
        {
            return string.Format("UnLocode: {0}", UnLocode);
        }

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.UnLocode, UnLocode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Location)) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            return UnLocode.GetHashCode();
        }

        public static bool operator ==(Location left, Location right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !Equals(left, right);
        }
    }

    public class UnLocode : IEquatable<UnLocode>
    {
        public readonly string LocationCode;

        public UnLocode(string locationCode)
        {
            LocationCode = locationCode;
        }

        public override string ToString()
        {
            return string.Format("LocationCode: {0}", LocationCode);
        }

        public bool Equals(UnLocode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.LocationCode, LocationCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UnLocode)) return false;
            return Equals((UnLocode) obj);
        }

        public override int GetHashCode()
        {
            return LocationCode.GetHashCode();
        }

        public static bool operator ==(UnLocode left, UnLocode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnLocode left, UnLocode right)
        {
            return !Equals(left, right);
        }
    }
}