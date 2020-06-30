using Application.DataTransfer;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetSingleLoad : IQuery<int, LoadDto>
    {
    }
}
