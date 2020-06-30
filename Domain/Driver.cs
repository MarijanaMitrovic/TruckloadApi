using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Driver : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TruckId { get; set; }
      
        public virtual Truck Truck { get; set; }

        public virtual ICollection<DriverLoad> DriverLoads { get; set; }
           = new HashSet<DriverLoad>();
    }
}
