using Empresas.Domain.Models;
using Empresas.Domain.Repositories;
using Empresas.Infrastructure.Query.Helpers;
using Empresas.Infrastructure.Query.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Empresas.Infrastructure.Query.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddQueryInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(sp =>
            {
                return new MongoDbHelper(connectionString);
            });

            services.AddScoped<IQueryRepository<Empresa>, EmpresaQueryRepository>();

            return services;
        }
    }
}
