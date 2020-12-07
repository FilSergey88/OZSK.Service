using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;

namespace OZSK.Service.Configuration
{
    public class DefaultModule:Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .Where(q => q.Name.EndsWith("QueryHandler") || q.Name.EndsWith("QueryHandlerAsync"))
                .AsImplementedInterfaces().AsSelf().SingleInstance();
        }


    }
}
