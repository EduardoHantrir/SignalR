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

        private Guid GetUserIdFromToken()
        {
            var userId = _tokenService.GetUserIdFromToken();
            if (userId == Guid.Empty)
                throw new ErrorLists(new List<string> { "Token inválido." });
            return userId;
        }

        public async Task<UserParams> GetUserByIdAsync(Guid? userId = null)
        {
            if (userId == Guid.Empty || userId is null)
                userId = GetUserIdFromToken();

            var user = await _userRepository.GetUserByIdAsync(userId!.Value);

            user = new SignalR_Domains.User.User();

            if (user == null)
                throw new ErrorLists(new List<string> { "Usuario não encontrado." });

            return new UserParams(user);
        }

        public async Task<List<UserParams>> GetAllUsersAsync()
        {
            var userId = GetUserIdFromToken();

            var users = await _userRepository.GetAllUsersAsync();

            return users.Select(u => new UserParams(u)).ToList();
        }

        public async Task<List<UserParams>> SearchUsersAsync(string query)
        {
            var userId = GetUserIdFromToken();

            var users = await _userRepository.GetUsersByFilterAsync(query);

            return users.Select(u => new UserParams(u)).ToList();
        }

        public async Task<UserParams> CreateUserAsync(UserParams @params)
        {
            var user = await SignalR_Domains.User.User.Create(@params);

            var token = _tokenService.GenerateToken(user);

            return new UserParams(user);
        }

        public async Task<UserParams> UpdateUserAsync(UserParams @params)
        {
            var userId = GetUserIdFromToken();

            var existingUser = await _userRepository.GetUserByIdAsync(userId);

            var updatedUser = await SignalR_Domains.User.User.Update(existingUser, @params);

            return new UserParams(updatedUser);
        }

        public async Task<bool> DeleteUserAsync()
        {
            var userId = _tokenService.GetUserIdFromToken();

            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
