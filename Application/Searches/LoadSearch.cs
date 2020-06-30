using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
   public class LoadSearch : PagedSearch
    {
        public string From { get; set; }
        public string To { get; set;  }
    }
}
