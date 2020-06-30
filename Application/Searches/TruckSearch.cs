using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class TruckSearch : PagedSearch
    {
        public string RegistrationMark { get; set; }
        public int Label { get; set; }
     }
   
}
