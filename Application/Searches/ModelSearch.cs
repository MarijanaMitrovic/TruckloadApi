using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ModelSearch : PagedSearch
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
