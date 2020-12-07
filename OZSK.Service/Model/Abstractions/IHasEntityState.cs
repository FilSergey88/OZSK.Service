using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Model.Abstractions
{
    public interface IHasEntityState
    {
        EntityState EntityState { get; set; }
    }

    public enum EntityState
    {
        None,
        Edited,
        Deleted,
        Added
    }
}
