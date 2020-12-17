using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Queries.Abstractions;
using OZSK.Service.Model;

namespace OZSK.Service.Queries
{
    public class
        GetCarrierQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<Model.Carrier>>, IEnumerable<Model.Carrier>>
    {
        public GetCarrierQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory,
            mapper)
        {
        }

        public override async Task<IEnumerable<Model.Carrier>> HandleAsync(EmptyQuery<IEnumerable<Model.Carrier>> query,
            CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            return await context.Carriers
                .ToListAsync(cancellationToken);
        }
    }
}