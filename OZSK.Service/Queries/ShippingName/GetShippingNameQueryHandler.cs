using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.ShippingName
{
    public class GetShippingNameQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<Model.ShippingName>>,
        IEnumerable<Model.ShippingName>>
    {
        public GetShippingNameQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(
            connectionFactory, mapper)
        {
        }

        public override async Task<IEnumerable<Model.ShippingName>> HandleAsync(
            EmptyQuery<IEnumerable<Model.ShippingName>> query, CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            return await context.ShippingNames
                .ToListAsync(cancellationToken);
        }
    }
}