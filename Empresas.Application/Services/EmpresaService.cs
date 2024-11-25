using Empresas.Domain.Models;
using Empresas.Domain.Repositories;
using Empresas.Infrastructure.Query.Repositories;

namespace Empresas.Application.Services
{
    public class EmpresaService
    {
        private readonly ICommandRepository<Empresa> _commandRepository;
        private readonly IQueryRepository<Empresa> _queryRepository;
        private readonly EmpresaQueryRepository _empresaQueryRepository;

        public EmpresaService(
            ICommandRepository<Empresa> commandRepository, IQueryRepository<Empresa> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _empresaQueryRepository = (EmpresaQueryRepository)queryRepository;
        }

        public async Task AddEmpresaAsync(Empresa empresa)
        {
            await _commandRepository.InsertAsync(empresa);
            await _empresaQueryRepository.InsertAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            await _commandRepository.UpdateAsync(empresa);
            await _empresaQueryRepository.UpdateAsync(empresa);
        }

        public async Task DeleteEmpresaAsync(Empresa empresa)
        {
            await _commandRepository.DeleteAsync(empresa);
            await _empresaQueryRepository.DeleteAsync(empresa);
        }

        public async Task<Empresa?> GetByIdAsync(int id)
        {
            return await _queryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _queryRepository.GetAllAsync();
        }
    }
}
