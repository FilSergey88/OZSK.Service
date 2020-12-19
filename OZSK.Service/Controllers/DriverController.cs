using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Commands.Auto;
using OZSK.Service.Commands.Driver;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Queries.Driver;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Driver>> GetCarrier([FromServices] GetDriverQueryHandler queryHandler,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new EmptyQuery<IEnumerable<Driver>>(), cancellationToken);
        }
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

        [HttpPost]
        [Route("CreateOrUpdate")]
        public async Task CreateOrUpdateCarrier(
            [FromServices] CreateOrUpdateDriverCommandHandler commandHandler,
            DTODriver driver,
            CancellationToken cancellationToken)
        {
            await commandHandler.HandleAsync(new CreateOrUpdateDriverCommand
            {
                Driver= driver
            }, cancellationToken);
        }
    }
}
