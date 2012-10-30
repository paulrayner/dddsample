namespace dddsample
{
    public class Location
    {
        public readonly UnLocode UnLocode;

        // Java example requires client of Location having to specify timezone etc - should just
        // be able to pass in the United Nations location code
        public static Location Dallas = new Location("USDAL");

        public Location(string locationCode)
        {
            UnLocode = new UnLocode(locationCode);
        }
    }


    public class UnLocode
    {
        public readonly string Code;

        public UnLocode(string usdal)
        {
            Code = usdal;
        }
    }
}