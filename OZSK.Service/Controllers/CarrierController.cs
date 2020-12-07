using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Commands.Carrier;
using OZSK.Service.Model;
using OZSK.Service.Queries;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Queries.Carrier;

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

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<DTOCarrier> GetCarrierById([FromServices] GetCarrierByIdQueryHandler queryHandler,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new GetCarrierByIdQuery
            {
                Id = id
            }, cancellationToken);
        }

        [HttpPost]
        [Route("CreateOrUpdate")]
        public async Task CreateOrUpdateCarrier(
            [FromServices] CreateOrUpdateCarrierCommandHandler commandHandler, 
            DTOCarrier carrier,
            CancellationToken cancellationToken)
        {
            await commandHandler.HandleAsync(new CreateOrUpdateCarrierCommand
            {
                Carrier = carrier
            }, cancellationToken);
        }
    }
}