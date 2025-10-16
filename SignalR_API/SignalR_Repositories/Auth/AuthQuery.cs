using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Repositories.Auth
{
    public class AuthQuery
    {
        public static string GetUserByEmailQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * From Users");
            sb.AppendLine("WHERE Email = @Email");
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
            sb.AppendLine("TimeZoneOffset, ");
            sb.AppendLine("CreatedAt");
            sb.AppendLine(")");
            sb.AppendLine("VALUES (");
            sb.AppendLine("@id, ");
            sb.AppendLine("@UserName, ");
            sb.AppendLine("@Email, ");
            sb.AppendLine("@Password, ");
            sb.AppendLine("@TimeZoneOffset, ");
            sb.AppendLine("@CreatedAt");
            sb.AppendLine(");");

            return sb.ToString();
        }
    }
}
