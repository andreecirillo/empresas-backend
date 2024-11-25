using Empresas.Domain.Models;
using Empresas.Domain.Repositories;
using Empresas.Infrastructure.Command.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Empresas.Infrastructure.Command.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCommandInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(provider => new NHibernateHelper(connectionString));

            services.AddScoped(factory =>
            {
                return factory.GetRequiredService<NHibernateHelper>().OpenSession();
            });

            services.AddScoped<ICommandRepository<Empresa>, EmpresaCommandRepository>();

            return services;
        }
    }
}
