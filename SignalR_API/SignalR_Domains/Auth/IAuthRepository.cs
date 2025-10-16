

namespace SignalR_Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<bool> CreateUserAsync(SignalR_Domains.User.User user);
        Task<SignalR_Domains.User.User> GetUserByEmailAsync(string email);
    }
}