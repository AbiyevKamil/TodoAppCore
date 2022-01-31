using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TodoAppCore.Entities;

namespace TodoAppCore.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        Task<AppUser> GetUser(ClaimsPrincipal claims);

        Task<IEnumerable<Todo>> GetUserTasks(AppUser user);
    }
}
