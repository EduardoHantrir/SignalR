using SignalR_Domains.User;
using SignalR_Domains.Users;

namespace SignalR_Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public async Task<SignalR_Domains.User.User> GetUserByIdAsync(Guid userId)
        {
            return new SignalR_Domains.User.User();
        }

        public async Task<List<SignalR_Domains.User.User>> GetAllUsersAsync()
        {
            return new List<SignalR_Domains.User.User>();
        }

        public async Task<List<SignalR_Domains.User.User>> GetUsersByFilterAsync(string filter)
        {
            return new List<SignalR_Domains.User.User>();
        }

        public async Task<SignalR_Domains.User.User> CreateUserAsync(UserParams @params)
        {
            var user = await SignalR_Domains.User.User.Create(@params);
            // Here you would typically add code to save the user to a database
            return user;
        }

        public async Task<SignalR_Domains.User.User> UpdateUserAsync(SignalR_Domains.User.User user, UserParams @params)
        {
            var updatedUser = await SignalR_Domains.User.User.Update(user, @params);
            // Here you would typically add code to save the updated user to a database
            return updatedUser;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return true;
        }
    }
}
