using System;
using System.Collections.Generic;

namespace dddsample
{
    public class RoutingService
    {
        public static Itinerary FetchRoutesForSpecification(RouteSpecification routeSpecification)
        {
            // TODO Remove hard-coding here
            var leg = new Leg(Location.HongKong, Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs = new List<Leg> { leg };

            return new Itinerary(legs);
        }
    }
}