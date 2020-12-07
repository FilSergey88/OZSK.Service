using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Model
{
    public class DTOAuto : IHasEntityState, IHasTimeStamp
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        public string PTS { get; set; }
        public string STS { get; set; }
        public IEnumerable<DTODriver> Drivers { get; set; }
        public EntityState EntityState { get; set; }
        public byte[] Ts { get; set; }
    }
}
