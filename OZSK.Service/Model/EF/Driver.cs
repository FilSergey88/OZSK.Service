using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Model
{
    public class Driver : IHasTimeStamp
    {
        public int Id { get; set; }

        public int AutoId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public Auto Auto{ get; set; }
        public byte[] Ts { get; set; }
    }
}
