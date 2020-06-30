using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class TruckDto
    {

        public int Id { get; set; }
        public string RegistrationMark { get; set; }
        public int Label { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


}

    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }
    }
}
