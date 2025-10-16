using SignalR_Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Domains.Auth
{
    public class AuthParams
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public AuthParams() { }

        public Task ValidateParams()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Email))
                errors.Add("E-mail é obrigatorio.");

            if (string.IsNullOrWhiteSpace(Password))
                errors.Add("Senha é obrigatorio.");

            if (errors.Count != 0)
                throw new ErrorLists("Erros encontrados:", errors);

            return Task.CompletedTask;
        }
    }
}
