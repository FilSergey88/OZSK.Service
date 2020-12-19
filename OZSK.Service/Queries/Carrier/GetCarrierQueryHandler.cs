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
using EntityState = OZSK.Service.Model.Abstractions.EntityState;

namespace OZSK.Service.Queries
{
    public class
        GetCarrierQueryHandler : BaseQueryHandler<EmptyQuery<IEnumerable<DTOCarrier>>, IEnumerable<DTOCarrier>>
    {
        public GetCarrierQueryHandler(IConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory,
            mapper)
        {
        }

        public override async Task<IEnumerable<DTOCarrier>> HandleAsync(EmptyQuery<IEnumerable<DTOCarrier>> query,
            CancellationToken cancellationToken)
        {
            await using var context = ConnectionFactory.GetContext();


            var res3 = await context.Carriers
                .Select(q => new DTOCarrier
                {
                    Id = q.Id,
                    Address = q.Address,
                    Contact = q.Contact,
                    EntityState = EntityState.None,
                    Name = q.Name,
                    SEO = q.SEO,
                    Ts = q.Ts,
                    Autos = q.Autos.Select(p => new DTOAuto
                    {
                        Ts = p.Ts,
                        EntityState = EntityState.None,
                        Brand = p.Brand,
                        CarrierId = p.CarrierId,
                        Id = p.CarrierId,
                        Number = p.Number,
                        PTS = p.PTS,
                        STS = p.STS,
                        Drivers = p.Drivers.Select(s => new DTODriver
                        {
                            Id = s.Id,
                            AutoId = s.AutoId,
                            EntityState = EntityState.None,
                            Name = s.Name,
                            Number = s.Number,
                            Ts = s.Ts
                        })
                    })
                }).ToListAsync(cancellationToken);

            return res3;
        }
    }
}