using TodoAppCore.Entities;

namespace TodoAppCore.Core.IRepositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<Note> GetById(int id, AppUser user);
    }
}
