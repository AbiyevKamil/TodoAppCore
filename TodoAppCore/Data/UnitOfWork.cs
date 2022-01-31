using Microsoft.AspNetCore.Identity;
using TodoAppCore.Core.IConfiguration;
using TodoAppCore.Core.IRepositories;
using TodoAppCore.Core.Repositories;
using TodoAppCore.Entities;

namespace TodoAppCore.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> _userManager;
        public IUserRepository Users { get; private set; }


        public ITodoRepository Todos { get; private set; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory, UserManager<AppUser> userManager)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logger");
            _userManager = userManager;

            Users = new UserRepository(_context, _logger, _userManager);
            Todos = new TodoRepository(_context, _logger);
        }

        public virtual async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
