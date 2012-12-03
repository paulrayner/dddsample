using dddsample.Model.Shared;

namespace dddsample.Model.Cargo
{
    public enum TransportStatus
    {
        Claimed,
        NotReceived,
        InPort,
        OnboardCarrier,
        Unknown
    };

        // Define an extension method in a non-nested static class. 
    public static class Extensions
    {
        public static TransportStatus DeriveTransportStatus(this TransportStatus transportStatus,
                                                             HandlingActivity handlingActivity)
        {
            switch (handlingActivity.Type)
            {
                case HandlingActivityType.Load:
                    return TransportStatus.OnboardCarrier;
                case HandlingActivityType.Receive:
                    return TransportStatus.InPort;
                case HandlingActivityType.Claim:
                    return TransportStatus.Claimed;
                default:
                    return TransportStatus.Unknown;
            }
        }
    }
}