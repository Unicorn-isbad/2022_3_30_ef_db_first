using System;
using System.Collections.Generic;

namespace ef_db_first_drivers.Models
{
    public partial class Trophy
    {
        public int TrophyId { get; set; }
        public short TrophyYear { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; } = null!;
    }
}
