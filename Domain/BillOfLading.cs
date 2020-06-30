using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class BillOfLading : Entity
    {
        public int LoadId { get; set; }
        public int DriverId { get; set; }
        public string Image { get; set; }

        public virtual Load Load { get; set; }
        public virtual Driver Driver { get; set; }

    }
}
