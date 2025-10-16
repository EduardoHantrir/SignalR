using SignalR_Domains;
using SignalR_Domains.Interface;
using SignalR_Domains.User;
using SignalR_Domains.Users;
using SignalR_Errors;
using System;
using System.Text.RegularExpressions;

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
                throw new ErrorLists(["Token inválido."]);

            return userId;
        }

        public async Task<UserParams> GetUserByIdAsync(Guid? userId = null)
        {
            if (userId == Guid.Empty || userId is null)
                userId = GetUserIdFromToken();

            var user = await _userRepository.GetUserByIdAsync(userId!.Value);

            if (user == null)
                throw new ErrorLists(["Usuario não encontrado."]);

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
            if (string.IsNullOrWhiteSpace(query))
                throw new ErrorLists(["Query inválida."]);   

            query = query.Trim();

            var querys = Regex.Split(query, @"[^A-Za-z0-9À-ÿ]+");

            var userId = GetUserIdFromToken();

            var users = await _userRepository.GetUsersByFilterAsync(querys);

            return users.Select(u => new UserParams(u)).ToList();
        }

        public async Task<bool> HasEmailRegisterAsync(string email)
        {
            if (await _userRepository.HasEmailRegisterAsync(email))
                return true;

            return false;
        }

        public async Task<UserParams> CreateUserAsync(UserParams @params)
        {
            var user = await SignalR_Domains.User.User.Create(@params);

            if (await HasEmailRegisterAsync(@params.Email!))
                throw new ErrorLists(["Email já cadastrado "]);

            await _userRepository.CreateUserAsync(user);

            return new UserParams(user);
        }

        public async Task<UserParams> UpdateUserAsync(UserParams @params)
        {
            var userId = GetUserIdFromToken();

            var existingUser = await _userRepository.GetUserByIdAsync(userId);

            if(existingUser.Email != @params.Email)
            {
                if (await HasEmailRegisterAsync(@params.Email!))
                    throw new ErrorLists(["Email já cadastrado "]);
            }

            var updatedUser = await SignalR_Domains.User.User.Update(existingUser, @params);
        
            await _userRepository.UpdateUserAsync(updatedUser);

            return new UserParams(updatedUser);
        }

        public async Task<bool> DeleteUserAsync()
        {
            var userId = _tokenService.GetUserIdFromToken();

            var existingUser = await _userRepository.GetUserByIdAsync(userId);

            if (existingUser == null)
                throw new ErrorLists(["Usuario não encontrado."]);

            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
