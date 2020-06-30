using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class BolSearch : PagedSearch
    {
        public int LoadId { get; set; }
        public int DriverId { get; set; }
    }
}
