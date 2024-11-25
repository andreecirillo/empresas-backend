using Microsoft.Extensions.DependencyInjection;
using Empresas.Infrastructure.Query.Extensions;
using Empresas.Infrastructure.Command.Extensions;
using Empresas.Application.Services;

namespace Empresas.Application.Configurations
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string commandConnectionString, string queryConnectionString)
        {
            services.AddCommandInfrastructure(commandConnectionString);
            services.AddQueryInfrastructure(queryConnectionString);
            services.AddScoped<EmpresaService>();

            return services;
        }
    }
}
