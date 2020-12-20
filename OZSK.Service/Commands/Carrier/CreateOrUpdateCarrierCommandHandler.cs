using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.Commands.Abstractions;
using OZSK.Service.Commands.Auto;
using OZSK.Service.DataBase;
using OZSK.Service.EF;
using OZSK.Service.Model;
using EntityState = OZSK.Service.Model.Abstractions.EntityState;

namespace OZSK.Service.Commands.Carrier
{
    public class CreateOrUpdateCarrierCommandHandler : BaseSaveCommandHandler<CreateOrUpdateCarrierCommand>
    {

        public CreateOrUpdateCarrierCommandHandler(IMapper mapper, IConnectionFactory connectionFactory) : base(mapper,
            connectionFactory)
        {
        }

        public override async Task HandleAsync(CreateOrUpdateCarrierCommand command,
            CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Model.Carrier>(command.Carrier);
            entity.Autos = null;
            await using var context = ConnectionFactory.GetContext();
            await using var tran = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                switch (command.Carrier.EntityState)
                {
                    case EntityState.Added:
                        await CreateCarrier(context, entity, cancellationToken);
                        break;
                    case EntityState.Edited:
                        await UpdateCarrier(context, entity, cancellationToken);
                        break;
                    case EntityState.Deleted:
                        await DeleteCarrier(context, entity, cancellationToken);
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

        private async Task DeleteCarrier(Context context, Model.Carrier entity, CancellationToken cancellationToken)
        {
            var autos = await context.Autos.Where(q => q.CarrierId == entity.Id).ToListAsync(cancellationToken);
            foreach (var one in autos)
            {
                var driver = await context.Drivers.Where(q => q.AutoId == one.Id).ToListAsync(cancellationToken);
                context.RemoveRange(driver);
            }
            context.RemoveRange(autos);
            var carrier = await context.Carriers.FirstOrDefaultAsync(q => q.Id == entity.Id, cancellationToken);
            context.Carriers.Remove(carrier);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateCarrier(Context context, Model.Carrier carrier, CancellationToken cancellationToken)
        {
            await context.Carriers.AddAsync(carrier, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateCarrier(Context context, Model.Carrier newCarrier, CancellationToken cancellationToken)
        {
            context.Update(newCarrier);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}