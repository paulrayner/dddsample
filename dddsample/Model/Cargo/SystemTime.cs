using System;

namespace dddsample.Model.Cargo
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}