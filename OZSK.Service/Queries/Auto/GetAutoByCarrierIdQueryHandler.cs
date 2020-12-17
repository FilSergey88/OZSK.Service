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
using OZSK.Service.Queries.Carrier;

namespace OZSK.Service.Queries.Auto
{
    public class GetAutoByCarrierIdQueryHandler : BaseQueryHandler<GetAutoByCarrierIdQuery, IEnumerable<DTOAuto>>
    {
        public GetAutoByCarrierIdQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory, mapper)
        {
        }

        public override async Task<IEnumerable<DTOAuto>> HandleAsync(GetAutoByCarrierIdQuery query, CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            var carrier = await context.Autos
                .Where(q => q.CarrierId == query.CarrierId)
                .ProjectTo<DTOAuto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return carrier;
        }
    }
}
