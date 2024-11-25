using MongoDB.Driver;
using Empresas.Infrastructure.Query.Helpers;
using Empresas.Domain.Models;
using Empresas.Domain.Repositories;

namespace Empresas.Infrastructure.Query.Repositories
{
    public class EmpresaQueryRepository : IQueryRepository<Empresa>
    {
        private readonly IMongoCollection<Empresa> _empresas;

        public EmpresaQueryRepository(MongoDbHelper mongoDbHelper)
        {
            _empresas = mongoDbHelper.GetCollection<Empresa>("empresas");
        }

        public async Task<Empresa?> GetByIdAsync(int id)
        {
            return await _empresas.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _empresas.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(Empresa empresa)
        {
            var filter = Builders<Empresa>.Filter.Eq(e => e.Id, empresa.Id);
            await _empresas.ReplaceOneAsync(filter, empresa);
        }

        public async Task InsertAsync(Empresa empresa)
        {
            await _empresas.InsertOneAsync(empresa);
        }

        public async Task DeleteAsync(Empresa empresa)
        {
            var filter = Builders<Empresa>.Filter.Eq(e => e.Id, empresa.Id);
            await _empresas.DeleteOneAsync(filter);
        }
    }
}