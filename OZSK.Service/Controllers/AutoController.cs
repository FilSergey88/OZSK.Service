using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Commands.Auto;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Queries.Auto;
using OZSK.Service.Queries.Carrier;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController  :ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Auto>> GetCarrier([FromServices] GetAutoQueryHandler queryHandler,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new EmptyQuery<IEnumerable<Auto>>(), cancellationToken);
        }
        [HttpPost]
        [Route("CreateOrUpdate")]
        public async Task CreateOrUpdateCarrier(
            [FromServices] CreateOrUpdateAutoCommandHandler commandHandler,
            DTOAuto auto,
            CancellationToken cancellationToken)
        {
            await commandHandler.HandleAsync(new CreateOrUpdateAutoCommand
            {
                Auto = auto
            }, cancellationToken);
        }
    }
}
