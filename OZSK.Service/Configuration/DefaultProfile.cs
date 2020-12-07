using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OZSK.Service.Model;

namespace OZSK.Service.Configuration
{
    public class DefaultProfile:Profile
    {
        public DefaultProfile()
        {
            CreateMap<DTOCarrier, Carrier>(MemberList.None)
                .ForMember(q=>q.Autos, c=>c.Ignore());
            CreateMap<DTOAuto, Auto>(MemberList.None)
                .ForMember(q => q.Drivers, c => c.Ignore());
            CreateMap<DTODriver, Driver>(MemberList.None);

            CreateMap<Carrier, DTOCarrier>(MemberList.None);
            CreateMap<Auto, DTOAuto>(MemberList.None);

            CreateMap<Driver, DTODriver>(MemberList.None);
        }
    }
}
