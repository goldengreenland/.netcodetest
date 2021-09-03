using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Estore.Core.Entities.Const;
using Estore.Core.Repository;
using Estore.Core.Repository.Repositories;
using Estore.Core.Service;
using Estore.Core.Service.Manager;
using Estore.Core.Service.Proxy;
using Estore.Core.Api.Authentication;

namespace Estore.Core.Api.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValidationManager, ValidationManager>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IBuyTypeRepository, BuyTypeRepository>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IPurchaseHistoryService, PurchaseHistoryService>();
            services.AddScoped<IProxyService, ProxyService>();
            services.AddScoped<ICoreProxy, CoreProxy>();
            return services;
        }

        public static IServiceCollection RegisterAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationConsts.PcmsApiUrl = configuration["EStore:PcmsApiUrl"];
            ConfigurationConsts.TimeOut = int.Parse(configuration["EStore:TimeOut"]);
            ConfigurationConsts.MasterKey = configuration["Jwt:MasterKey"];
            ConfigurationConsts.SessionTimeOutMinutes = int.Parse(configuration["EStore:SessionTimeOutMinutes"]);

            ConfigurationConsts.DBConnectionString = configuration["ConnectionStrings:DbConnectionString"];

            services.AddDbContextPool<EStoreDbContext>(options => options.UseMySql(ConfigurationConsts.DBConnectionString,
                ServerVersion.AutoDetect(ConfigurationConsts.DBConnectionString)));

            return services;
        }
    }
}
