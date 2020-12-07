using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Carrier
{
    public class GetCarrierByIdQuery :IQuery<DTOCarrier>
    {
        public int Id { get; set; }
    }
}
