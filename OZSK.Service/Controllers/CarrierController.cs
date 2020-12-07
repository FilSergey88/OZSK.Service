using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Queries;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Carrier>> GetCarrier([FromServices] GetCarrierQueryHandler queryHandler,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new EmptyQuery<IEnumerable<Carrier>>(), cancellationToken);
        }
    }
}
