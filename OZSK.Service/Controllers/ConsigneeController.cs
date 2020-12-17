using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Model.DTO;
using OZSK.Service.Queries.Carrier;
using OZSK.Service.Queries.Consignee;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsigneeController : ControllerBase
    {
        [HttpGet]
        [Route("ById/{id}")]
        public async Task<DTOConsignee> GetCarrierById([FromServices] GetConsigneeByIdQueryHandler queryHandler,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new GetConsigneeByIdQuery()
            {
                Id = id
            }, cancellationToken);
        }
    }
}
