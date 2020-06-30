using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
   public class BolDto
    {
       
        public string Image { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int LoadId { get; set; }
        public int DriverId { get; set; }
    }
}
