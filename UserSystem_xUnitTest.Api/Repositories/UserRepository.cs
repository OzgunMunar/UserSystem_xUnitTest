using Microsoft.EntityFrameworkCore;
using UserSystem_xUnitTest.Api.Context;
using UserSystem_xUnitTest.Api.Models;

namespace UserSystem_xUnitTest.Api.Repositories
{
    public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
    {

        public async Task<bool> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(user, cancellationToken);
            var result = await context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Remove(user);
            var result = await context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Users.ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(cancellationToken);
        }
    }

}
