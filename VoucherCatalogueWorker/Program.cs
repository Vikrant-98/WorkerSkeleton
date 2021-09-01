using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.BlobService;
using MessagePack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VoucherCatalogueWorker.Process;
using VoucherCatalogueWorker.Services.DBServices;

namespace VoucherCatalogueWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                 #region MessagePackWithSecurity for Deserialization
                 var options = MessagePackSerializerOptions.Standard.WithSecurity(MessagePackSecurity.UntrustedData);
                 MessagePackSerializer.DefaultOptions = options;
                 #endregion

                 #region AddStackExchangeRedisCache
                 services.AddStackExchangeRedisCache(o =>
                 {
                     o.Configuration = hostContext.Configuration["Redis:Uri"];
                     o.InstanceName = hostContext.Configuration["Redis:env"];
                 });
                 #endregion
                 services.AddTransient<DBContext>(_ => new DBContext(hostContext.Configuration["MySQLConnectionStrings:Connection"]));
                 services.AddTransient<DBConnectServices>();
                 services.AddTransient<BlobStoragService>();
                 services.AddTransient<Processor>();
                 services.AddHostedService<Worker>();
                });
    }
}
