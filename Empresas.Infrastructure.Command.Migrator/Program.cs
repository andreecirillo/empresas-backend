using Empresas.Infrastructure.Command.Migrations;

namespace Empresas.Infrastructure.Command.Migrator
{
    using System;
    using FluentMigrator.Runner;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Erro: Informe a string de conexão como o primeiro argumento.");
                return;
            }

            string connectionString = args[0];
            Console.WriteLine($"Usando a string de conexão: {connectionString}");

            // Configuração de serviços
            var serviceProvider = CreateServices(connectionString);

            // Executa as migrations
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(EmpresaTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            try
            {
                Console.WriteLine("Executando as migrations...");
                runner.MigrateUp();
                Console.WriteLine("Migrations executadas com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar migrations: {ex.Message}");
            }
        }
    }

}
