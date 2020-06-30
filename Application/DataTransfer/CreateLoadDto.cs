using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateLoadDto
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Delivery { get; set; }
        public decimal Weight { get; set; }
        public int Miles { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<CreateDriverLoadDto> Items { get; set; } = new List<CreateDriverLoadDto>();
    }

    public class CreateDriverLoadDto
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
