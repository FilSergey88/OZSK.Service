using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OZSK.Service.Configuration
{
    public static class DataBaseSetting
    {
        public static void AddDataBaseSetting(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionstring = new SqlConnectionStringBuilder
            {
                // InitialCatalog = Environment.GetEnvironmentVariable("DBName"),
                // DataSource = Environment.GetEnvironmentVariable("DBServer"),
                InitialCatalog = Environment.GetEnvironmentVariable("DBName") ??
                                 configuration.GetValue<string>("DBName"),
                DataSource = Environment.GetEnvironmentVariable("DBServer") ??
                             configuration.GetValue<string>("DBServer"),
                PersistSecurityInfo = true,
                IntegratedSecurity = true
            };
            var constingdict = new Dictionary<string, string>
            {
                {
                    "OZSK", connectionstring.ConnectionString
                }
            };
            service.Configure<DBConnectionFactoryOptions>(opt => { opt.ConnectionStringDictionary = constingdict; });
        }
    }

    public class DBConnectionFactoryOptions
    {
        public Dictionary<string, string> ConnectionStringDictionary { get; set; }
    }
}