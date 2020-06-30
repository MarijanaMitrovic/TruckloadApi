using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetSingleTruck : IQuery<int, TruckDto>
    {
    }
}
