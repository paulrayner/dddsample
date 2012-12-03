using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dddsample.Model.Handling
{
    public class HandlingHistory
    {
        public List<HandlingEvent> HandlingEvents { get; private set; }
        public Cargo.Cargo Cargo { get; private set; }
    }
}
