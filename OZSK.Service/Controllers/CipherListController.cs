using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZSK.Service.Model;
using OZSK.Service.Model.DTO;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Queries.Cipherlist;

namespace OZSK.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CipherListController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<DTOCipherList>> GetCarrier([FromServices] GetCipherlistsQueryHandler queryHandler,
            CancellationToken cancellationToken)
        {
            return await queryHandler.HandleAsync(new EmptyQuery<IEnumerable<DTOCipherList>>(), cancellationToken);
        }
    }
}
