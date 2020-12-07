﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZSK.Service.Commands.Abstractions;
using OZSK.Service.Model;

namespace OZSK.Service.Commands.Auto
{
    public class CreateOrUpdateAutoCommand : ICommand
    {
        public DTOAuto Auto { get; set; }
    }
}
