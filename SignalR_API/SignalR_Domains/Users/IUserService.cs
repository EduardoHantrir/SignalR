using SignalR_Domains.User;

namespace SignalR_Domains.Users
{
    public interface IUserService
    {
        Task<UserParams> CreateUserAsync(UserParams userParams);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<List<UserParams>> GetAllUsersAsync();
        Task<UserParams> GetUserByIdAsync(Guid? userId = null);
        Task<List<UserParams>> SearchUsersAsync(string query);
        Task<UserParams> UpdateUserAsync(Guid userId, UserParams userParams);
    }
}