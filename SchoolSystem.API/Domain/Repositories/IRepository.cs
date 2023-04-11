namespace SchoolSystem.API.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        ValueTask InsertAsync(T entity);
        ValueTask<List<T>> SelectAllAsync();
        ValueTask<T?> SelectOneAsync(int id);
        void UpdateAsync(T entity);
    }
}