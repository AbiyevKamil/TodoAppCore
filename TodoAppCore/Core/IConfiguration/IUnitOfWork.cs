using TodoAppCore.Core.IRepositories;

namespace TodoAppCore.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        public ITodoRepository Todos { get; }
        public IUserRepository Users { get; }

        public Task CompleteAsync();
    }
}
