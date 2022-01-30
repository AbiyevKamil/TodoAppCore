using TodoAppCore.Core.IRepositories;

namespace TodoAppCore.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        public INoteRepository Notes { get; }
        public IUserRepository Users { get; }

        public Task CompleteAsync();
    }
}
