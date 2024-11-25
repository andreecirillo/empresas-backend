using Empresas.Domain.Models;
using Empresas.Domain.Repositories;
using NHibernate;

namespace Empresas.Infrastructure.Command.Repositories
{
    public class EmpresaCommandRepository : ICommandRepository<Empresa>
    {
        private readonly ISession _session;

        public EmpresaCommandRepository(ISession session)
        {
            _session = session;
        }

        public async Task InsertAsync(Empresa entity)
        {
            using var transaction = _session.BeginTransaction();

            await _session.SaveAsync(entity);

            await transaction.CommitAsync();
        }

        public async Task UpdateAsync(Empresa entity)
        {
            using var transaction = _session.BeginTransaction();

            await _session.MergeAsync(entity);

            await transaction.CommitAsync();
        }

        public async Task DeleteAsync(Empresa entity)
        {
            using var transaction = _session.BeginTransaction();

            await _session.RefreshAsync(entity);
            await _session.DeleteAsync(entity);

            await transaction.CommitAsync();
        }
    }

}
