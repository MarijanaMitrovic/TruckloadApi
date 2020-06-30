using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Truck : Entity
    {
        public string RegistrationMark { get; set; }
        public int Label { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
