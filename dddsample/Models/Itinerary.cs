using System;
using System.Collections.Generic;

namespace dddsample
{
    public class Itinerary : IEquatable<Itinerary>
    {
        public List<Leg> Legs { get; private set; }

        public Itinerary(List<Leg> legs)
        {
            Legs = legs;
        }

        public bool Equals(Itinerary other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Legs, Legs);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Itinerary)) return false;
            return Equals((Itinerary) obj);
        }

        public override int GetHashCode()
        {
            return Legs.GetHashCode();
        }

        public static bool operator ==(Itinerary left, Itinerary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Itinerary left, Itinerary right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Legs: {0}", Legs);
        }
    }
}