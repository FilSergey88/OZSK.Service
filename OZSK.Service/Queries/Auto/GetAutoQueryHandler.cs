using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Auto
{
    public class GetAutoQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<Model.Auto>>, IEnumerable<Model.Auto>>
    {
        public GetAutoQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory,
            mapper)
        {
        }

        public override async Task<IEnumerable<Model.Auto>> HandleAsync(EmptyQuery<IEnumerable<Model.Auto>> query,
            CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            return await context.Autos
                .ToListAsync(cancellationToken);
        }
    }
}