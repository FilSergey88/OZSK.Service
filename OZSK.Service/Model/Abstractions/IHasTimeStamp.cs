using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Model.Abstractions
{
    public interface IHasTimeStamp
    {
        byte[] Ts { get; set; }
    }
}
