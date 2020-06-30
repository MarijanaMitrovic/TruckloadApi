using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateTruckDto
    {
        public int Id { get; set; }
        public string RegistrationMark { get; set; }
        public int Label { get; set; }
        public int ModelId { get; set; }
    }
}
