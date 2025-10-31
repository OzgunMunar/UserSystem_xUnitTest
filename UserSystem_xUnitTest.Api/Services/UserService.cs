using FluentValidation;
using System.Diagnostics;
using UserSystem_xUnitTest.Api.DTOs;
using UserSystem_xUnitTest.Api.Models;
using UserSystem_xUnitTest.Api.Repositories;
using UserSystem_xUnitTest.Api.Validators;

namespace UserSystem_xUnitTest.Api.Services
{
    public sealed class UserService(
        IUserRepository userRepository,
        ILogger<User> logger
        ) : IUserService
    {
        public async Task<bool> CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default)
        {

            CreateUserDtoValidator validationRules = new();
            var result = validationRules.Validate(request);

            if(!result.IsValid)
            {
                throw new ValidationException(string.Join(", ", result.Errors.Select(s => s.ErrorMessage)));
            }

            User user = new()
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName
            };

            logger.LogInformation("Creating user with Id {0} and name: {1}", user.Id, user.FullName);
            
            var stopwatch = Stopwatch.StartNew();

            try
            {
                return await userRepository.CreateAsync(user, cancellationToken);
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "Something went wrong while createing user.");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation("User with id: {0} created in {1}ms", user.Id, stopwatch.ElapsedMilliseconds);
            }

        }

        public async Task<bool> DeleteByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            User? user = await userRepository.GetByIdAsync(Id, cancellationToken);
            if (user is null)
            {
                throw new ArgumentException("User not found");
            }

            logger.LogInformation("Deleting user with id: {0}", user.Id);
            var stopWatch = Stopwatch.StartNew();
            try
            {
                return await userRepository.DeleteAsync(user, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something went wrong while deleting user");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogInformation("User with id: {0} deleted in {1}ms", user.Id, stopWatch.ElapsedMilliseconds);
            }
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Retrieving all users");
            var stopWatch = Stopwatch.StartNew();
            try
            {
                return await userRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something went wrong while retrieving all users");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogInformation("All users retrieved in {0}ms", stopWatch.ElapsedMilliseconds);
            }
        }

        public async Task<User?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Retrieving user with id: {0}", Id);
            var stopWatch = Stopwatch.StartNew();
            try
            {
                return await userRepository.GetByIdAsync(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something went wrong while retrieving user with id: {0}", Id);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogInformation("User with id: {0} retrieved in {1}ms", Id, stopWatch.ElapsedMilliseconds);
            }
        }
    }
}
