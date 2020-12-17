using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Model.DTO
{
    public class DTOConsignee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public byte[] Ts { get; set; }
    }
}
