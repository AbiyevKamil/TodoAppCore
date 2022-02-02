using TodoAppCore.Entities;

namespace TodoAppCore.Core.IRepositories
{
    public interface ITodoRepository : IGenericRepository<Todo>
    {
        Task<Todo> GetById(int id, AppUser user);

        Task<bool> DeleteById(int id, AppUser user);
        Task<bool> DeleteByIdSoft(int id, AppUser user);
        Task<bool> CompleteTodo(int id);
    }
}
