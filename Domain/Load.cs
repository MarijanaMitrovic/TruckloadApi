using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Load : Entity
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Delivery { get; set; }
        public decimal Weight { get; set; }
        public int Miles { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DriverLoad> DriverLoads { get; set; } = new HashSet<DriverLoad>();

    }
}
