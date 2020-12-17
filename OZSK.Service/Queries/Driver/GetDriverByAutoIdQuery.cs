using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Driver
{
    public class GetDriverByAutoIdQuery : IQuery<IEnumerable<DTODriver>>
    {
        public int AutoId { get; set; }
    }
}
