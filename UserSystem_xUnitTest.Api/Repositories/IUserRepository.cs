using UserSystem_xUnitTest.Api.Models;

namespace UserSystem_xUnitTest.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(User user, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(User user, CancellationToken cancellationToken = default);
    }

}
