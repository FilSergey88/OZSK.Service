using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.Commands.Abstractions;
using OZSK.Service.DataBase;
using OZSK.Service.EF;
using EntityState = OZSK.Service.Model.Abstractions.EntityState;


namespace OZSK.Service.Commands.Driver
{
    public class CreateOrUpdateDriverCommandHandler : BaseSaveCommandHandler<CreateOrUpdateDriverCommand>
    {

        public CreateOrUpdateDriverCommandHandler(IMapper mapper, IConnectionFactory connectionFactory) : base(mapper,
            connectionFactory)
        {
        }

        public override async Task HandleAsync(CreateOrUpdateDriverCommand command,
            CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Model.Driver>(command.Driver);
            await using var context = ConnectionFactory.GetContext();
            await using var tran = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await Validate(command, context, cancellationToken);
                switch (command.Driver.EntityState)
                {
                    case EntityState.Added:
                        await CreateDriver(context, entity, cancellationToken);
                        break;
                    case EntityState.Edited:
                        await UpdateDriver(context, entity, cancellationToken);
                        break;
                    case EntityState.Deleted:
                        await DeleteDriver(context, entity, cancellationToken);
                        break;
                }

                await tran.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await tran.RollbackAsync(cancellationToken);
                throw;
            }
        }

        private async Task DeleteDriver(Context context, Model.Driver entity, CancellationToken cancellationToken)
        {
            context.Drivers.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateDriver(Context context, Model.Driver Driver, CancellationToken cancellationToken)
        {
            await context.Drivers.AddAsync(Driver, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateDriver(Context context, Model.Driver newDriver, CancellationToken cancellationToken)
        {
            context.Update(newDriver);
            await context.SaveChangesAsync(cancellationToken);
        }
        private async Task Validate(CreateOrUpdateDriverCommand command, Context context, CancellationToken cancellationToken)
        {
            if (command.Driver.EntityState != EntityState.Deleted)
            {
                var carrier =
                    await context.Autos.FirstOrDefaultAsync(q => q.Id == command.Driver.AutoId, cancellationToken);
                if (carrier == null)
                    throw new Exception("Такого авто нет");
            }
        }
    }
}