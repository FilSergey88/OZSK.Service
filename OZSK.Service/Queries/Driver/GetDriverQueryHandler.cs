using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Driver
{
    public class GetDriverQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<Model.Driver>>, IEnumerable<Model.Driver>>
    {
        public GetDriverQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory,
            mapper)
        {
        }

        public override async Task<IEnumerable<Model.Driver>> HandleAsync(EmptyQuery<IEnumerable<Model.Driver>> query,
            CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            return await context.Drivers
                .ToListAsync(cancellationToken);
        }
    }
}
