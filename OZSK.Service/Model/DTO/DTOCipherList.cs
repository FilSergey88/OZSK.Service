using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Model.DTO
{
    public class DTOCipherList
    {
        public int Id { get; set; }
        public int ConsigneeId { get; set; }
        public string Name { get; set; }
        public Consignee Consignee { get; set; }
        public byte[] Ts { get; set; }
    }
}
