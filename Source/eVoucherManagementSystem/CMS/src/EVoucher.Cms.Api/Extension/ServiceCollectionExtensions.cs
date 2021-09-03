using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EVoucher.Cms.Entities.Const;
using EVoucher.Cms.Repository;
using EVoucher.Cms.Repository.Repositories;
using EVoucher.Cms.Service;
using EVoucher.Cms.Service.Manager;

namespace EVoucher.Cms.Api.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValidationManager, ValidationManager>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IBuyTypeRepository, BuyTypeRepository>();
            services.AddScoped<IVoucherService, VoucherService>();
            return services;
        }

        public static IServiceCollection RegisterAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationConsts.DBConnectionString = configuration["ConnectionStrings:DbConnectionString"];

            services.AddDbContextPool<EVoucherDbContext>(options => options.UseMySql(ConfigurationConsts.DBConnectionString,
                ServerVersion.AutoDetect(ConfigurationConsts.DBConnectionString)));

            return services;
        }
    }
}
