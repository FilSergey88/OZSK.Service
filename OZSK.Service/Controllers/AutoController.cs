using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Queries.Auto;
using OZSK.Service.Queries.Carrier;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController  :ControllerBase
    {
        [HttpGet]
        [Route("ByCarrierId/{carrierId}")]
        public async Task<IEnumerable<DTOAuto>> GetCarrierById([FromServices] GetAutoByCarrierIdQueryHandler queryHandler,
            [FromRoute] int carrierId,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new GetAutoByCarrierIdQuery()
            {
                CarrierId = carrierId
            }, cancellationToken);
        }
    }
}
