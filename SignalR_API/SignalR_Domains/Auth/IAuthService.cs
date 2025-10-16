using SignalR_Domains.Auth;
using SignalR_Domains.User;

namespace SignalR_Services.Auth
{
    public interface IAuthService
    {
        Task<(UserParams, string)> LoginAsync(AuthParams authParams);
        Task<bool> RegisterAsync(UserParams userParams);
        Task<bool> ResetPasswordAsync(string token, string newPassword);
        Task<bool> SendForgotPasswordEmailAsync(string email);
    }
}