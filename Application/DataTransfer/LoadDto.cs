using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class LoadDto
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Delivery { get; set; }
        public decimal Weight { get; set; }
        public int Miles { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<DriverLoadDto> DriverLoads { get; set; } = new List<DriverLoadDto>();
    }

    public class DriverLoadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
