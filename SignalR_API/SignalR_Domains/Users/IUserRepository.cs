using SignalR_Domains.User;

namespace SignalR_Domains.Users
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User.User user);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<List<User.User>> GetAllUsersAsync();
        Task<User.User> GetUserByIdAsync(Guid userId);
        Task<List<User.User>> GetUsersByFilterAsync(string[] filter);
        Task<bool> HasEmailRegisterAsync(string email);
        Task<bool> UpdateUserAsync(User.User user);
    }
}