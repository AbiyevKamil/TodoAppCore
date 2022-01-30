using Microsoft.AspNetCore.Identity;
using TodoAppCore.Entities;

namespace TodoAppCore.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<IdentityResult> CreateAsync(AppUser user);
        Task<IdentityResult> LoginAsync(AppUser user);
        Task<IdentityResult> Logout();

        Task<AppUser> GetUser(string id);

        Task<IEnumerable<Task>> GetUserTasks(AppUser user);
    }
}
