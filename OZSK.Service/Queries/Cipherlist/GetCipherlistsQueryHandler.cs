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

namespace OZSK.Service.Queries.Cipherlist
{
    public class GetCipherlistsQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<DTOCipherList>>, IEnumerable<DTOCipherList>>
    {
        public GetCipherlistsQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory,
            mapper)
        {
        }

        public override async Task<IEnumerable<DTOCipherList>> HandleAsync(EmptyQuery<IEnumerable<DTOCipherList>> query,
            CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();
            return await context.Cipherlists
                .ProjectTo<DTOCipherList>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}