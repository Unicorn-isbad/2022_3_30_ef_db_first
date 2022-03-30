using System;
using System.Collections.Generic;

namespace ef_db_first_drivers.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Trophies = new HashSet<Trophy>();
        }

        public int DriverId { get; set; }
        public string DriverName { get; set; } = null!;

        public virtual ICollection<Trophy> Trophies { get; set; }
    }
}
