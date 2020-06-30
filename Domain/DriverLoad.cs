using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class DriverLoad : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? DriverId { get; set; }
        public int LoadId { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Load Load { get; set; }

    }
}
