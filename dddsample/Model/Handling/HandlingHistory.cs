using System.Collections.Generic;

namespace dddsample.Model.Handling
{
    public class HandlingHistory
    {
        public List<HandlingEvent> HandlingEvents { get; private set; }
        public Cargo.Cargo Cargo { get; private set; }

        public HandlingHistory(Cargo.Cargo cargo)
        {
            Cargo = cargo;
            HandlingEvents = new List<HandlingEvent>();
        }
    }
}