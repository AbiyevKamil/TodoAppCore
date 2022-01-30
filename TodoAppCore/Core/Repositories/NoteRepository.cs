using Microsoft.EntityFrameworkCore;
using TodoAppCore.Core.IRepositories;
using TodoAppCore.Data;
using TodoAppCore.Entities;

namespace TodoAppCore.Core.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public virtual async Task<Note> GetById(int id, AppUser user)
        {
            var task = await dbSet.FirstOrDefaultAsync(i => i.Id == id && i.AppUserId == user.Id);
            return task;
        }
    }
}
