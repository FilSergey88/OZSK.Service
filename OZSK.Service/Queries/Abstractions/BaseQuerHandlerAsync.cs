using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OZSK.Service.DataBase;

namespace OZSK.Service.Queries.Abstractions
{
    public abstract class BaseQuerHandler<TQuery, TResult> : IQueryHandlerAsync<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected readonly IConnectionFactory ConnectionFactory;
        protected BaseQuerHandler(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }
        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
