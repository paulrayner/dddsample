using System;

namespace dddsample.Model.Voyage
{
    public class Voyage : IEquatable<Voyage>
    {
        public VoyageNumber VoyageNumber { get; private set; }

        public Voyage(VoyageNumber voyageNumber)
        {
            VoyageNumber = voyageNumber;
        }

        public static Voyage None = new Voyage(new VoyageNumber(""));   // NULL object pattern

        public bool Equals(Voyage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.VoyageNumber, VoyageNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Voyage)) return false;
            return Equals((Voyage) obj);
        }

        public override int GetHashCode()
        {
            return VoyageNumber.GetHashCode();
        }

        public static bool operator ==(Voyage left, Voyage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Voyage left, Voyage right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("VoyageNumber: {0}", VoyageNumber);
        }
    }

    public class VoyageNumber : IEquatable<VoyageNumber>
    {
        public String Number { get; private set; }

        public VoyageNumber(string number)
        {
            Number = number;
        }

        public bool Equals(VoyageNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Number, Number);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (VoyageNumber)) return false;
            return Equals((VoyageNumber) obj);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public static bool operator ==(VoyageNumber left, VoyageNumber right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VoyageNumber left, VoyageNumber right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Number: {0}", Number);
        }
    }
}