using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Model
{
    public class Auto
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        public string PTS { get; set; }
        public string STS { get; set; }
    }
}