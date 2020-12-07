using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Model
{
    public class Cipherlist : IHasTimeStamp
    {
        public int Id { get; set; }
        public string ConsigneeId { get; set; }
        public int Name { get; set; }
        public byte[] Ts { get; set; }
    }
}
