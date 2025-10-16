using SignalR_Domains.User;

namespace SignalR_Domains.Users
{
    public interface IUserService
    {
        Task<UserParams> CreateUserAsync(UserParams userParams);
        Task<List<UserParams>> GetAllUsersAsync();
        Task<UserParams> GetUserByIdAsync(Guid? userId = null);
        Task<List<UserParams>> SearchUsersAsync(string query);
        Task<bool> HasEmailRegisterAsync(string email);
        Task<UserParams> UpdateUserAsync(UserParams userParams);
        Task<bool> DeleteUserAsync();
    }
}