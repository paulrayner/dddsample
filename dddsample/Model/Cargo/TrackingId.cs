using System;

namespace dddsample.Model.Cargo
{
    public class TrackingId : IEquatable<TrackingId>
    {
        public String Id { get; private set; }

        public TrackingId(String id)
        {
            Id = id;
        }

        public bool Equals(TrackingId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Id, Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TrackingId)) return false;
            return Equals((TrackingId) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(TrackingId left, TrackingId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TrackingId left, TrackingId right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Id: {0}", Id);
        }
    }
}
