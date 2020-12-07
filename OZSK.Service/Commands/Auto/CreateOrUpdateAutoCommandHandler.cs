using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OZSK.Service.Commands.Abstractions;
using OZSK.Service.DataBase;
using OZSK.Service.EF;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Commands.Auto
{
    public class CreateOrUpdateAutoCommandHandler : BaseSaveCommandHandler<CreateOrUpdateAutoCommand>
    {
        public CreateOrUpdateAutoCommandHandler(IMapper mapper, IConnectionFactory connectionFactory) : base(mapper,
            connectionFactory)
        {
        }

        public override async Task HandleAsync(CreateOrUpdateAutoCommand command,
            CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Model.Auto>(command.Auto);
            entity.Drivers = null;
            await using var context = ConnectionFactory.GetContext();
            await using var tran = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                switch (command.Auto.EntityState)
                {
                    case EntityState.Added:
                        await CreateAuto(context, entity, cancellationToken);
                        break;
                    case EntityState.Edited:
                        await UpdateAuto(context, entity, cancellationToken);
                        break;
                    case EntityState.Deleted:
                        await DeleteAuto(context, entity, cancellationToken);
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

        private async Task DeleteAuto(Context context, Model.Auto entity, CancellationToken cancellationToken)
        {
            context.Autos.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateAuto(Context context, Model.Auto Auto, CancellationToken cancellationToken)
        {
            await context.Autos.AddAsync(Auto, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateAuto(Context context, Model.Auto newAuto, CancellationToken cancellationToken)
        {
            context.Update(newAuto);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}