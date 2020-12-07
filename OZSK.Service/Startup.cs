using System;
using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OZSK.Service.Configuration;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using OZSK.Service.DataBase;
using OZSK.Service.MiddleWares;


namespace OZSK.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Startup.Configuration = configuration;

            var envPath = Path.Combine(env.ContentRootPath, ".env");
            DotNetEnv.Env.Load(envPath);

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                };
                return settings;
            };
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors()
                .AddSingleton<IConnectionFactory, DbConnectionFactory>()
                .AddMvcCore()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
                .AddApiExplorer()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services
                .AddAutoMapper(typeof(Startup)) // Check out Configuration/AutoMapperProfiles/DefaultProfile to do actual configuration. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#automapper
                .AddSwagger();                  // Check out Configuration/DependenciesConfig.cs/AddSwagger to do actual configuration. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#documenting-api

            services.AddRouting();
            services.AddControllers();
            services.AddHealthChecks();
            services.AddDataBaseSetting(Configuration);
            services.AddAutoMapper((Action<IServiceProvider, IMapperConfigurationExpression>) null,
                AppDomain.CurrentDomain.GetAssemblies());

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DefaultModule>();
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }


        public void ConfigureProductionContainer(ContainerBuilder builder)
        {
            ConfigureContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandlerEx();

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app
                .UseSwaggerWithOptions();   // Check out Configuration/MiddlewareConfig.cs/UseSwaggerWithOptions to do actual configuration. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#documenting-api


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecks(Constants.Health.EndPoint); // See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#health-checks
            });

            logger.LogInformation("Server configuration is completed");
        }
    }
}
