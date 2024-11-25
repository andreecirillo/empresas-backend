namespace Empresas.Domain.Repositories
{
    public interface IQueryRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
