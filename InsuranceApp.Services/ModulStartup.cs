
using InsuranceApp.Data;
using InsuranceApp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApp.Services
{
    public static class ModulStartup
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            // Repositories
            services.AddRepositories();

            // Services
            services.AddScoped<InsuredPersonService>();
            services.AddScoped<InsuranceService>();

            return services;
        }
    }
}
