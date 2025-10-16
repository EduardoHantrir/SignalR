using Microsoft.Data.SqlClient;
using SignalR_Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDatabaseRepository _db;

        public AuthRepository(IDatabaseRepository db)
        {
            _db = db;
        }

        public async Task<SignalR_Domains.User.User> GetUserByEmailAsync(string email)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.GetUserByEmailQuery();

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", email);

            var reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                return new SignalR_Domains.User.User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    TimeZoneOffset = reader.GetInt32(reader.GetOrdinal("TimeZoneOffset")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    LastUpdatedAt = reader.GetDateTime(reader.GetOrdinal("LastUpdatedAt")),
                    IsActive = reader!.GetBoolean(reader.GetOrdinal("IsActive"))
                };
            }

            throw new ErrorLists(new List<string> { "Usuario não encontrado." });
        }

        public async Task<bool> CreateUserAsync(SignalR_Domains.User.User user)
        {
            using var connection = _db.GetConnetion();

            var query = AuthQuery.CreateUserQuery();

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@TimeZoneOffset", user.TimeZoneOffset);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }
    }
}
