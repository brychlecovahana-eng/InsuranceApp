
using InsuranceApp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApp.Data
{
    public static class ModulStartup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<InsuredPersonRepository>();
            services.AddScoped<InsuranceRepository>();

            return services;
        }
    }
}
