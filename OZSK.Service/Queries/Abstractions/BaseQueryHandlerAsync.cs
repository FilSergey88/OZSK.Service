using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OZSK.Service.DataBase;

namespace OZSK.Service.Queries.Abstractions
{
    public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandlerAsync<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected readonly IConnectionFactory ConnectionFactory;
        protected readonly IMapper Mapper;
        protected BaseQueryHandler(IConnectionFactory connectionFactory, IMapper mapper)
        {
            ConnectionFactory = connectionFactory;
            Mapper = mapper;
        }
        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
