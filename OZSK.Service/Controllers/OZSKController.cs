using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OZSK.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OZSKController : Controller
    {
        [HttpGet]
        [Route("ShippingName")]
        public Task<string> GetShippingName(CancellationToken cancellationToken)
        {
            return Task.FromResult($"Uploaded");
        }
    }
}
