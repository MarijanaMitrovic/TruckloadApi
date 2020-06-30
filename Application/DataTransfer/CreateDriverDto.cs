using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
   public class CreateDriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TruckId { get; set; }
    }
}
