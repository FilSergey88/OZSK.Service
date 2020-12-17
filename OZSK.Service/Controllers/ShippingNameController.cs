using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Queries.ShippingName;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingNameController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ShippingName>> GetCarrier([FromServices] GetShippingNameQueryHandler queryHandler,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new EmptyQuery<IEnumerable<ShippingName>>(), cancellationToken);
        }
    }
}
