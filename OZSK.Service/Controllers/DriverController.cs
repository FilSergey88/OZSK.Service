using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Queries.Driver;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet]
        [Route("ByAutoId/{autoId}")]
        public async Task<IEnumerable<DTODriver>> GetCarrierById([FromServices] GetDriverByAutoIdQueryHandler queryHandler,
            [FromRoute] int autoId,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new GetDriverByAutoIdQuery()
            {
                AutoId = autoId
            }, cancellationToken);
        }
    }
}
