using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR_Domains.Auth;
using SignalR_Domains.Result;
using SignalR_Domains.User;
using SignalR_Errors;
using SignalR_Services.Auth;
using System.Data;

namespace SignalR_API.Controllers
{
    [ApiController]
    [Route("api/v0/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController
            (
            IAuthService authService
            )
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(AuthParams authParams)
            {
            try
            {
                var loginResult = await _authService.LoginAsync(authParams);

                var userResult = loginResult.Item1;
                var token = loginResult.Item2;

                Response.Headers.Append("Authorization", $"Bearer {token}");

                return Ok(Results<UserParams>.SucessResult(userResult, [token]));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(UserParams userParams)
        {
            try
            {
                await _authService.RegisterAsync(userParams);
                return Ok(Results<bool>.SucessResult(true));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> UserForgotPassword()
        {
            try
            {
                var userResult = new UserParams();
                return Ok(Results<UserParams>.SucessResult(userResult));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }

        [HttpPost("reset-password")]
        [Authorize]
        public async Task<IActionResult> UserResetPassword()
        {
            try
            {
                var userResult = new UserParams();
                return Ok(Results<UserParams>.SucessResult(userResult));
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult([.. ex.Errors]));
            }
        }
    }
}
