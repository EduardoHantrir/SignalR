using Microsoft.Data.SqlClient;
using SignalR_Domains.User;
using SignalR_Domains.Users;
using SignalR_Errors;
using System.Reflection.PortableExecutable;

namespace SignalR_Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseRepository _db;
        public UserRepository(IDatabaseRepository db)
        {
            _db = db;
        }

        public async Task<SignalR_Domains.User.User> GetUserByIdAsync(Guid userId)
        {

            using var connection = _db.GetConnetion();

            var query = AuthQuery.GetUserByIdQuery();

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", userId);

            var reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                return new SignalR_Domains.User.User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    AvatarUrl = reader.IsDBNull(reader.GetOrdinal("AvatarUrl")) ? null : reader.GetString(reader.GetOrdinal("AvatarUrl")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    TimeZoneOffset = reader.GetInt32(reader.GetOrdinal("TimeZoneOffset")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    LastUpdatedAt = reader.IsDBNull(reader.GetOrdinal("LastUpdatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastUpdatedAt")),
                    IsActive = reader!.GetBoolean(reader.GetOrdinal("IsActive"))
                };
            }

            throw new ErrorLists(new List<string> { "Usuario não encontrado." });
        }

        public async Task<bool> HasEmailRegisterAsync(string email)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.GetUserByEmailQuery();

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", email);

            var reader = await command.ExecuteReaderAsync();

            if (reader.Read())
                return true;

            return false;
        }
        public async Task<List<SignalR_Domains.User.User>> GetAllUsersAsync()
        {
            return new List<SignalR_Domains.User.User>();
        }

        public async Task<List<SignalR_Domains.User.User>> GetUsersByFilterAsync(string[] filter)
        {
            using var connection = _db.GetConnetion();

            var quantitySearch = filter.Length;
            var query = AuthQuery.GetUserBySearchQuery(quantitySearch);

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);
            for (int i = 0; i < quantitySearch; i++)
            {
                command.Parameters.AddWithValue($"@Search{i}", $"%{filter[i]}%");
            }

            using var reader = await command.ExecuteReaderAsync();

            var users = new List<SignalR_Domains.User.User>();

            while (reader.Read())
            {
                var user = new SignalR_Domains.User.User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    AvatarUrl = reader.IsDBNull(reader.GetOrdinal("AvatarUrl")) ? null : reader.GetString(reader.GetOrdinal("AvatarUrl")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    TimeZoneOffset = reader.GetInt32(reader.GetOrdinal("TimeZoneOffset")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    LastUpdatedAt = reader.IsDBNull(reader.GetOrdinal("LastUpdatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastUpdatedAt")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                };
                users.Add(user);
            }

            return users;
        }

        public async Task<bool> CreateUserAsync(SignalR_Domains.User.User user)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.CreateUserQuery();

            if (user.AvatarUrl is null)
            {
                query = query.Replace("@AvatarUrl, ", "");
                query = query.Replace("AvatarUrl, ", "");
            }

            if (user.Description is null)
            {
                query = query.Replace("@Description, ", "");
                query = query.Replace("Description, ", "");
            }

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            if (user.AvatarUrl is not null)
                command.Parameters.AddWithValue("@AvatarUrl", user.AvatarUrl);

            if (user.Description is not null)
                command.Parameters.AddWithValue("@Description", user.Description);

            command.Parameters.AddWithValue("@TimeZoneOffset", user.TimeZoneOffset);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

            await command.ExecuteNonQueryAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(SignalR_Domains.User.User user)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.UpdateUserQuery();

            if (user.AvatarUrl is null)
            {
                query = query.Replace("@AvatarUrl, ", "");
                query = query.Replace("AvatarUrl, ", "");
            }

            if (user.Description is null)
            {
                query = query.Replace("@Description, ", "");
                query = query.Replace("Description, ", "");
            }

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);

            if (user.AvatarUrl is not null)
                command.Parameters.AddWithValue("@AvatarUrl", user.AvatarUrl);

            if (user.Description is not null)
                command.Parameters.AddWithValue("@Description", user.Description);

            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@TimeZoneOffset", user.TimeZoneOffset);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            command.Parameters.AddWithValue("@LastUpdatedAt", user.LastUpdatedAt!);
            
            await command.ExecuteNonQueryAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.DeleteUserQuery();

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", userId);

            await command.ExecuteNonQueryAsync();

            return true;
        }
    }
}
