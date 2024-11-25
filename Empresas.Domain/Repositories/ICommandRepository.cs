namespace Empresas.Domain.Repositories
{
    public interface ICommandRepository<T>
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
