using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Model : Entity
    {
        public string Name { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }

        public  virtual ICollection<Truck> Trucks{ get; set; } = new HashSet<Truck>();

    }
}
