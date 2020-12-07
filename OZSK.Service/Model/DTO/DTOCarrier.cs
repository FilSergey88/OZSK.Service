using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Model
{
    public class DTOCarrier : IHasEntityState, IHasTimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string SEO { get; set; }
        public string Address { get; set; }
        public IEnumerable<DTOAuto> Autos { get; set; }
        public EntityState EntityState { get; set; }
        public byte[] Ts { get; set; }
    }
}
