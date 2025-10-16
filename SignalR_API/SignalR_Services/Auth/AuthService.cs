using SignalR_Domains.Auth;
using SignalR_Domains.Interface;
using SignalR_Domains.User;
using SignalR_Domains.Users;
using SignalR_Errors;
using SignalR_Repositories.Auth;

namespace SignalR_Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthService
            (
                IAuthRepository authRepository,
                ITokenService tokenService,
                IUserService userService
            ) 
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<(UserParams, string)> LoginAsync(AuthParams authParams)
        {
            await authParams.ValidateParams();

            var user = await _authRepository.GetUserByEmailAsync(authParams.Email);

            if (user is null)
                throw new ErrorLists(["E-mail ou senha inválidos~."]);

            if (user.Password != authParams.Password)
                throw new ErrorLists(["E-mail ou senha inválidos~."]);

            var token = _tokenService.GenerateToken(user);

            return await Task.FromResult((new UserParams(user), token));
        }

        public async Task<bool> RegisterAsync(UserParams @params)
        {
            if (await _userService.HasEmailRegisterAsync(@params.Email!))
                throw new ErrorLists(["Email já cadastrado "]);

            var user = await SignalR_Domains.User.User.Create(@params);

            return await _authRepository.CreateUserAsync(user);

        }

        public async Task<bool> SendForgotPasswordEmailAsync(string email)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
