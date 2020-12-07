using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OZSK.Service.DataBase;

namespace OZSK.Service.Commands.Abstractions
{
    public abstract class BaseSaveCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly IMapper Mapper;
        protected readonly IConnectionFactory ConnectionFactory;

        public BaseSaveCommandHandler(IMapper mapper, IConnectionFactory connectionFactory)
        {
            Mapper = mapper;
            ConnectionFactory = connectionFactory;
        }

        public abstract Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
