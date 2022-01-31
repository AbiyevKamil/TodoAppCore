using Microsoft.EntityFrameworkCore;
using TodoAppCore.Core.IRepositories;
using TodoAppCore.Data;
using TodoAppCore.Entities;

namespace TodoAppCore.Core.Repositories
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public virtual async Task<Todo> GetById(int id, AppUser user)
        {
            var task = await dbSet.FirstOrDefaultAsync(i => i.Id == id && i.AppUserId == user.Id);
            return task;
        }

        public virtual async Task<bool> CompleteTodo(int id)
        {
            try
            {
                var exist = await dbSet.FirstOrDefaultAsync(i => i.Id == id);
                if (exist == null)
                    return false;
                exist.IsCompleted = true;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} CompleteTodo method error", typeof(ITodoRepository));
                return false;
            }
        }
    }
}
