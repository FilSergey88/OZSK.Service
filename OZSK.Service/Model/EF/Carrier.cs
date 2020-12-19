using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Model.Abstractions;

namespace OZSK.Service.Model
{
    public class Carrier : IHasTimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string SEO { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public virtual ICollection<Auto> Autos{ get; set; }
        public byte[] Ts { get; set; }
    }
}