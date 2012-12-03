using System;

namespace dddsample.Model.Cargo
{
    public class RouteSpecification : IEquatable<RouteSpecification>
    {
        public Location.Location Origin { get; private set; }
        public Location.Location Destination { get; private set; }

        public RouteSpecification(Location.Location origin, Location.Location destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public bool Equals(RouteSpecification other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Origin, Origin) && Equals(other.Destination, Destination);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RouteSpecification)) return false;
            return Equals((RouteSpecification) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Origin.GetHashCode()*397) ^ Destination.GetHashCode();
            }
        }

        public static bool operator ==(RouteSpecification left, RouteSpecification right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RouteSpecification left, RouteSpecification right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Origin: {0}, Destination: {1}", Origin, Destination);
        }
    }
}