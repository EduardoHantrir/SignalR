using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR_Domains.Result;
using SignalR_Domains.User;
using SignalR_Domains.Users;
using SignalR_Errors;

namespace SignalR_API.Controllers
{
    [ApiController]
    [Route("api/v0/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController 
            (
                IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var userResult = await _userService.GetUserByIdAsync(id);
                return Ok(Results<UserParams>.SucessResult(userResult));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                var userResult = await _userService.GetUserByIdAsync();

                return Ok(Results<UserParams>.SucessResult(userResult));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                return Ok(Results<List<UserParams>>.SucessResult(users));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> SearchUsers([FromQuery] string query)
        {
            try
            {
                var users = await _userService.SearchUsersAsync(query);

                return Ok(Results<List<UserParams>>.SucessResult(users));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser(UserParams @params)
        {
            try
            {
                var user = await _userService.CreateUserAsync(@params);

                return Ok(Results<UserParams>.SucessResult(user));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserParams @params)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(@params);

                return Ok(Results<UserParams>.SucessResult(updatedUser));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                var status = await _userService.DeleteUserAsync();

                return Ok(Results<bool>.SucessResult(status));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }
    }
}
