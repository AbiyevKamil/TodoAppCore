using Microsoft.EntityFrameworkCore;
using TodoAppCore.Core.IRepositories;
using TodoAppCore.Data;

namespace TodoAppCore.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        protected ILogger _logger;
        protected DbSet<T> dbSet;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Add method error", typeof(GenericRepository<T>));
                return false;
            }
        }

        public virtual async Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
