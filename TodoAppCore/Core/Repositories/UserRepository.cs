using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoAppCore.Core.IRepositories;
using TodoAppCore.Data;
using TodoAppCore.Entities;

namespace TodoAppCore.Core.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(AppDbContext context, ILogger logger,
             UserManager<AppUser> userManager) : base(context, logger)
        {
            _userManager = userManager;
        }

        public virtual async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public virtual async Task<AppUser> GetUser(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            return user;
        }

        public virtual async Task<IEnumerable<Todo>> GetUserTasks(AppUser user)
        {
            return await _context.Todos.Include(i => i.AppUser).Where(i => i.AppUserId == user.Id).ToListAsync();
        }
    }
}
