using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.API.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SchoolDbContext context;
        public Repository(SchoolDbContext context)
        => this.context = context;


        public virtual async ValueTask InsertAsync(T entity)
            => await this.context.Set<T>().AddAsync(entity);
        public virtual void UpdateAsync(T entity)
            => this.context.Set<T>().Update(entity);
        public virtual async ValueTask<T?> SelectOneAsync(int id)
            => await this.context.Set<T>().FindAsync(id);

        public virtual async ValueTask<List<T>> SelectAllAsync()
            => await this.context.Set<T>().ToListAsync();
    }
}
