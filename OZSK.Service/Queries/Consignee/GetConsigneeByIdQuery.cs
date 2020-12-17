using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.DTO;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Consignee
{
    public class GetConsigneeByIdQuery : IQuery<DTOConsignee>
    {
        public int Id { get; set; }
    }
}
