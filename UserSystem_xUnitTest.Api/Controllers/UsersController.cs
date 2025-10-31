using Microsoft.AspNetCore.Mvc;
using UserSystem_xUnitTest.Api.DTOs;
using UserSystem_xUnitTest.Api.Services;

namespace UserSystem_xUnitTest.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await userService.GetAllAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
        {
            var users = await userService.GetByIdAsync(Id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            var result = await userService.CreateAsync(createUserDto);
            return Ok(new {Result = result});
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Delete(Guid Id, CancellationToken cancellationToken)
        {
            var result = await userService.DeleteByIdAsync(Id);
            return Ok(new { Result = result });
        }

    }
}
