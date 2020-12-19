using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OZSK.Service.Model;
using OZSK.Service.Model.DTO;

namespace OZSK.Service.Configuration
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<DTOCarrier, Carrier>(MemberList.None)
                .ForMember(q => q.Autos,
                    c => c.MapFrom(s => s.Autos))
                .ReverseMap();

            CreateMap<DTOAuto, Auto>(MemberList.None)
                .ForMember(q => q.Drivers, c => c.MapFrom(s => s.Drivers))
                .ReverseMap();
            CreateMap<DTODriver, Driver>(MemberList.None);

            CreateMap<Carrier, DTOCarrier>(MemberList.None);
            CreateMap<Auto, DTOAuto>(MemberList.None);

            CreateMap<Driver, DTODriver>(MemberList.None);
            CreateMap<Consignee, DTOConsignee>(MemberList.None);
            CreateMap<Auto, DTOAuto>(MemberList.None)
                .ForMember(q => q.Drivers, c => c.Ignore());
            CreateMap<Cipherlist, DTOCipherList>(MemberList.None)
                .ForMember(q => q.Consignee, c => c.MapFrom(s => s.Consignee));
        }
    }
}