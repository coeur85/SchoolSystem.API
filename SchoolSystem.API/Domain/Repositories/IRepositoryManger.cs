namespace SchoolSystem.API.Domain.Repositories
{
    public interface IRepositoryManger<T> where T : class
    {
        ValueTask InsertAsync(T entity);
        ValueTask<List<T>> SelectAllAsync();
        ValueTask<T?> SelectOneAsync(int id);
        ValueTask UpdateAsync(T entity);
        ValueTask DeleteAsync(T entity);
    }
}