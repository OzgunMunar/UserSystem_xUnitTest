using UserSystem_xUnitTest.Api.DTOs;
using UserSystem_xUnitTest.Api.Models;

namespace UserSystem_xUnitTest.Api.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
