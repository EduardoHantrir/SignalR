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
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var userResult = await _userService.GetUserByIdAsync(id);
                return Ok(Results<UserParams>.SucessResult(userResult));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                var userResult = await _userService.GetUserByIdAsync();
                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("search/{query}")]
        [Authorize]
        public async Task<IActionResult> SearchUsers(string query)
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserParams @params)
        {
            try
            {
                var user = await _userService.CreateUserAsync(@params);
                return Ok(Results<UserParams>.SucessResult(user));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                var user = await SignalR_Domains.User.User.Create(new SignalR_Domains.User.UserParams());
                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }
    }
}
