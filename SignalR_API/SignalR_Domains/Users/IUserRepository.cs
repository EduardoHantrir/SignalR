using SignalR_Domains.User;

namespace SignalR_Domains.Users
{
    public interface IUserRepository
    {
        Task<User.User> CreateUserAsync(UserParams @params);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<List<User.User>> GetAllUsersAsync();
        Task<User.User> GetUserByIdAsync(Guid userId);
        Task<List<User.User>> GetUsersByFilterAsync(string filter);
        Task<User.User> UpdateUserAsync(User.User user, UserParams @params);
    }
}