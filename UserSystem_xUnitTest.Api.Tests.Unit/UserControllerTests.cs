using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UserSystem_xUnitTest.Api.Controllers;
using UserSystem_xUnitTest.Api.DTOs;
using UserSystem_xUnitTest.Api.Models;
using UserSystem_xUnitTest.Api.Services;

namespace UserSystem_xUnitTest.Api.Tests.Unit
{
    public class UserControllerTests
    {
        
        private readonly UsersController _sut;
        private readonly IUserService _userService = Substitute.For<IUserService>();

        public UserControllerTests()
        {
            _sut = new(_userService);
        }

        [Fact]
        public async Task GetAll_ShouldReturnUsers()
        {

            // Arrange
            _userService.GetAllAsync().Returns(Enumerable.Empty<User>().ToList());

            // Act
            var result = (OkObjectResult)await _sut.GetAll(default);

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetById_ShouldReturnUser()
        {
            var userId = Guid.NewGuid();
            var user = new User()
            {
                Id = userId,
                FullName = "Özgün Munar",
            };
            // Arrange
            _userService.GetByIdAsync(userId).Returns(user);

            // Act
            var result = (OkObjectResult)await _sut.GetById(userId, default);

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task CreateAsync_ShouldReturnTrue()
        {
            var userId = Guid.NewGuid();
            var request = new CreateUserDto("Özgün Munar");

            // Arrange
            _userService.CreateAsync(request).Returns(true);

            // Act
            var result = (OkObjectResult)await _sut.Create(request, default);

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldReturnTrue()
        {
            var userId = Guid.NewGuid();

            // Arrange
            _userService.DeleteByIdAsync(userId).Returns(true);

            // Act
            var result = (OkObjectResult)await _sut.Delete(userId, default);

            // Assert
            result.StatusCode.Should().Be(200);

        }

    }

}