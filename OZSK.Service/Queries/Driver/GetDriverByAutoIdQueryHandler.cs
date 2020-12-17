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
using OZSK.Service.Queries.Auto;

namespace OZSK.Service.Queries.Driver
{
    public class GetDriverByAutoIdQueryHandler : BaseQueryHandler<GetDriverByAutoIdQuery, IEnumerable<DTODriver>>
    {
        public GetDriverByAutoIdQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory, mapper)
        {
        }

        public override async Task<IEnumerable<DTODriver>> HandleAsync(GetDriverByAutoIdQuery query, CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            var carrier = await context.Drivers
                .Where(q => q.AutoId== query.AutoId)
                .ProjectTo<DTODriver>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return carrier;
        }
    }
}
