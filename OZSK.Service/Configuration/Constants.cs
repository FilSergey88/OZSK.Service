using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZSK.Service.Configuration
{
    public class Constants
    {
        public static class Swagger
        {
            public static string EndPoint => $"../swagger/{Version}/swagger.json";
            public static string ApiName => "My API";
            public static string Version => "v1";
        }

        public static class Health
        {
            public static string EndPoint => "/health";
        }
    }
}
