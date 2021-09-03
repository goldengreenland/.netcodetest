using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pcms.Core.Entities.Const;
using Pcms.Core.Repository;
using Pcms.Core.Repository.Repositories;
using Pcms.Core.Service;

namespace Pcms.Core.Api.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();

            services.AddScoped<IPromoCodeService, PromoCodeService>();
            return services;
        }

        public static IServiceCollection RegisterAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationConsts.DBConnectionString = configuration["ConnectionStrings:DbConnectionString"];
            ConfigurationConsts.MasterKey = configuration["Jwt:MasterKey"];

            services.AddDbContextPool<PcmsDbContext>(options => options.UseMySql(ConfigurationConsts.DBConnectionString,
                ServerVersion.AutoDetect(ConfigurationConsts.DBConnectionString)));

            return services;
        }
    }
}
