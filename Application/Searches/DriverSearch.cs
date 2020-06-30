using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
   public class DriverSearch : PagedSearch
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
