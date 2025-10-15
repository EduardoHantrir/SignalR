using SignalR_Domains;
using SignalR_Domains.Interface;
using SignalR_Domains.User;
using SignalR_Domains.Users;
using SignalR_Errors;

namespace SignalR_Services.User
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public UserService
            (
                ITokenService tokenService,
                IUserRepository userRepository
            ) 
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }
        public async Task<UserParams> GetUserByIdAsync(Guid? userId = null)
        {
            if (userId == Guid.Empty || userId is null)
                userId = _tokenService.GetUserIdFromToken();

            var user = await _userRepository.GetUserByIdAsync(userId!.Value);

            user = new SignalR_Domains.User.User();

            if (user == null)
                throw new ErrorLists(new List<string> { "Usuario não encontrado." });

            return new UserParams(user);
        }

        public async Task<List<UserParams>> GetAllUsersAsync()
        {
            return new List<UserParams>();
        }

        public async Task<List<UserParams>> SearchUsersAsync(string query)
        {
            return new List<UserParams>();
        }

        public async Task<UserParams> CreateUserAsync(UserParams @params)
        {
            var user = await SignalR_Domains.User.User.Create(@params);

            var token = _tokenService.GenerateToken(user);

            return new UserParams(user);
        }

        public async Task<UserParams> UpdateUserAsync(Guid userId, UserParams @params)
        {
            var existingUser = new SignalR_Domains.User.User();
            var updatedUser = await SignalR_Domains.User.User.Update(existingUser, @params);
            return new UserParams(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return true;
        }
    }
}
