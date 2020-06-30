using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }
    }
}
