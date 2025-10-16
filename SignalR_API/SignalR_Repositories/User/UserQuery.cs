using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Repositories.User
{
    public class AuthQuery
    {
        public AuthQuery()
        {
        }

        public static string GetUserByIdQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * From Users");
            sb.AppendLine("WHERE Id = @Id");
            sb.AppendLine("AND IsActive = 1;");

            return sb.ToString();
        }

        public static string GetUserByEmailQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * From Users");
            sb.AppendLine("WHERE Email = @Email");
            sb.AppendLine("AND IsActive = 1;");

            return sb.ToString();
        }

        public static string GetAllUsersQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * From Users");
            sb.AppendLine("WHERE IsActive = true");
            sb.AppendLine("ORDER BY CreatedAt DESC;");
            return sb.ToString();
        }
        public static string GetUserBySearchQuery(int quantitySearch)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * From Users");
            sb.AppendLine("WHERE SearchIndex LIKE @Search" + 0);
            if (quantitySearch > 1)
            {
                for (int i = 1; i < quantitySearch; i++)
                {
                    sb.AppendLine("OR SearchIndex LIKE @Search" + i);
                }
            }
            sb.AppendLine("AND IsActive = 1;");

            return sb.ToString();
        }
        public static string CreateUserQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Users (");
            sb.AppendLine("Id, ");
            sb.AppendLine("UserName, ");
            sb.AppendLine("Email, ");
            sb.AppendLine("Password, ");
            sb.AppendLine("AvatarUrl, ");
            sb.AppendLine("Description, ");
            sb.AppendLine("TimeZoneOffset, ");
            sb.AppendLine("CreatedAt");
            sb.AppendLine(")");
            sb.AppendLine("VALUES (");
            sb.AppendLine("@id, ");
            sb.AppendLine("@UserName, ");
            sb.AppendLine("@Email, ");
            sb.AppendLine("@Password, ");
            sb.AppendLine("@AvatarUrl, ");
            sb.AppendLine("@Description, ");
            sb.AppendLine("@TimeZoneOffset, ");
            sb.AppendLine("@CreatedAt");
            sb.AppendLine(");");

            return sb.ToString();
        }
        public static string UpdateUserQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("UPDATE Users SET");
            sb.AppendLine("UserName = @UserName,");
            sb.AppendLine("Email = @Email,");
            sb.AppendLine("Password = @Password,");
            sb.AppendLine("AvatarUrl = @AvatarUrl,");
            sb.AppendLine("Description = @Description,");
            sb.AppendLine("TimeZoneOffset = @TimeZoneOffset,");
            sb.AppendLine("LastUpdatedAt = @LastUpdatedAt,");
            sb.AppendLine("IsActive = @IsActive");
            sb.AppendLine("WHERE Id = @Id");
            sb.AppendLine("AND IsActive = 1;");

            return sb.ToString();
        }
        public static string DeleteUserQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("UPDATE Users SET");
            sb.AppendLine("IsActive = 0");
            sb.AppendLine("WHERE Id = @Id;");

            return sb.ToString();
        }
    }
}
