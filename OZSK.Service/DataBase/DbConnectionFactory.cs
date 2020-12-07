using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OZSK.Service.Configuration;
using OZSK.Service.EF;

namespace OZSK.Service.DataBase
{
    public interface IConnectionFactory
    {
        Context GetContext();
    }

    public class DbConnectionFactory : IConnectionFactory
    {
        private readonly Dictionary<string, string> _connectionStringDictrionnary;
        private readonly DbContextOptionsBuilder<Context> _optionsBuilderContext;

        public DbConnectionFactory(IOptions<DBConnectionFactoryOptions> options)
        {
            var optionsValue = options.Value;
            _connectionStringDictrionnary = optionsValue.ConnectionStringDictionary;
            _optionsBuilderContext = new DbContextOptionsBuilder<Context>();
            _optionsBuilderContext.EnableSensitiveDataLogging()
                .UseSqlServer(_connectionStringDictrionnary["OZSK"]);
        }
        public DbConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var sqlConnection = (new SqlConnectionStringBuilder
            {
                InitialCatalog = config.GetValue<string>("DB_NAME"),
                DataSource = config.GetValue<string>("DB_SERVER"),
                PersistSecurityInfo = true,
                IntegratedSecurity = true
            }).ConnectionString;
            _optionsBuilderContext = new DbContextOptionsBuilder<Context>();
            _optionsBuilderContext
                .EnableSensitiveDataLogging()
                .UseSqlServer(sqlConnection);
        }

        public Context GetContext()
        {
            return new Context(_optionsBuilderContext.Options);
        }
    }
}
