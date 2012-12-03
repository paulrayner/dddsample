using System;
using dddsample.Model.Cargo;
using dddsample.Model.Shared;
using dddsample.Model.Voyage;

namespace dddsample.Model.Handling
{
    public class HandlingEvent : IEquatable<HandlingEvent>
    {
        public TrackingId CargoTrackingId { get; private set; }
        public DateTime CompletionTime { get; private set; }
        public DateTime RegistrationTime { get; private set; }
        public HandlingActivityType HandlingActivityType { get; private set; }
        public Location.Location Location { get; private set; }
        public VoyageNumber Number { get; private set; }
        public OperatorCode OperatorCode { get; private set; }

        public HandlingEvent(TrackingId cargoTrackingId,
                             DateTime completionTime,
                             DateTime registrationTime,
                             HandlingActivityType handlingActivityType,
                             Location.Location location,
                             VoyageNumber voyageNumber,
                             OperatorCode operatorCode)
        {
            CargoTrackingId = cargoTrackingId;
            CompletionTime = completionTime;
            RegistrationTime = registrationTime;
            HandlingActivityType = handlingActivityType;
            Location = location;
            Number = voyageNumber;
            OperatorCode = operatorCode;
        }

        public bool Equals(HandlingEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.CargoTrackingId, CargoTrackingId) && other.CompletionTime.Equals(CompletionTime) && other.RegistrationTime.Equals(RegistrationTime) && Equals(other.HandlingActivityType, HandlingActivityType) && Equals(other.Location, Location) && Equals(other.Number, Number) && Equals(other.OperatorCode, OperatorCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (HandlingEvent)) return false;
            return Equals((HandlingEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = CargoTrackingId.GetHashCode();
                result = (result*397) ^ CompletionTime.GetHashCode();
                result = (result*397) ^ RegistrationTime.GetHashCode();
                result = (result*397) ^ HandlingActivityType.GetHashCode();
                result = (result*397) ^ Location.GetHashCode();
                result = (result*397) ^ Number.GetHashCode();
                result = (result*397) ^ OperatorCode.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(HandlingEvent left, HandlingEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HandlingEvent left, HandlingEvent right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("CargoTrackingId: {0}, CompletionTime: {1}, RegistrationTime: {2}, HandlingActivityType: {3}, Location: {4}, Number: {5}, OperatorCode: {6}", CargoTrackingId, CompletionTime, RegistrationTime, HandlingActivityType, Location, Number, OperatorCode);
        }
    }

    public class OperatorCode : IEquatable<OperatorCode>
    {
        public string Code { get; private set; }

        public OperatorCode(String code)
        {
            Code = code;
        }

        public bool Equals(OperatorCode other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (OperatorCode)) return false;
            return Equals((OperatorCode) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator ==(OperatorCode left, OperatorCode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OperatorCode left, OperatorCode right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Code: {0}", Code);
        }
    }
}