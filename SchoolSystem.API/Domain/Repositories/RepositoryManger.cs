using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.API.Domain.Repositories
{
    public class RepositoryManger<T> : IRepositoryManger<T> where T : class
    {
        protected readonly SchoolDbContext context;
        public RepositoryManger(SchoolDbContext context)
        => this.context = context;


        public virtual async ValueTask InsertAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public virtual async ValueTask UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }

        public virtual async ValueTask DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public virtual async ValueTask<T?> SelectOneAsync(int id)
            => await this.context.Set<T>().FindAsync(id);
        public virtual async ValueTask<List<T>> SelectAllAsync()
            => await this.context.Set<T>().AsNoTracking().ToListAsync();

    }
}
