using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Model;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Carrier
{
    public class GetCarrierByIdQueryHandler : BaseQueryHandler<GetCarrierByIdQuery, DTOCarrier>
    {
        public GetCarrierByIdQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory, mapper)
        {
        }

        public override async Task<DTOCarrier> HandleAsync(GetCarrierByIdQuery query, CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            var carrier = await context.Carriers.ProjectTo<DTOCarrier>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == query.Id, cancellationToken);
            return carrier;
        }
    }
}
