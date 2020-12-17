using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.DataBase;
using OZSK.Service.Model.DTO;
using OZSK.Service.Queries.Abstractions;

namespace OZSK.Service.Queries.Consignee
{
    public class GetConsigneeByIdQueryHandler : BaseQueryHandler<GetConsigneeByIdQuery, DTOConsignee>
    {
        public GetConsigneeByIdQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory, mapper)
        {
        }

        public override async Task<DTOConsignee> HandleAsync(GetConsigneeByIdQuery query, CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            var result = await context.Consignees.ProjectTo<DTOConsignee>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == query.Id, cancellationToken);
            return result;
        }
    }
}
