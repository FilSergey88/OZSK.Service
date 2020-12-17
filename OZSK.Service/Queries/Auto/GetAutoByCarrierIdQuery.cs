using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Auto
{
    public class GetAutoByCarrierIdQuery : IQuery<IEnumerable<DTOAuto>>
    {
        public int CarrierId { get; set; }
    }
}
