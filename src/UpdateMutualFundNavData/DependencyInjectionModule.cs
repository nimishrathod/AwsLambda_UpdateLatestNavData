using Microsoft.Extensions.DependencyInjection;
using UpdateMutualFundNavData.Configuration;
using UpdateMutualFundNavData.Services;

namespace UpdateMutualFundNavData.DependencyResolver
{
    public class DependencyInjectionModule
    {
        public static IServiceCollection Container =>
            ConfigureServices();

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILambdaConfiguration, LambdaConfiguration>();
            services.AddTransient<IFundNavDataProviderService, FundNavDataProviderService>();
            services.AddTransient<IFundNavDataUpdaterService, FundNavDataUpdaterService>();
            return services;
        }
    }
}