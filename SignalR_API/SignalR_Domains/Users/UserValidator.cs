using SignalR_Errors;

namespace SignalR_Domains.User
{
    public class UserValidator
    {
        public static Task ValidateCreateParams
            (
            UserParams @params
            )
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(@params.UserName))
                errors.Add("Nome de usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(@params.Email))
                errors.Add("E-mail é obrigatório.");

            if (string.IsNullOrWhiteSpace(@params.Password))
                errors.Add("Senha é obrigatória.");

            if (@params.TimeZoneOffset is null)
                @params.TimeZoneOffset = -3;

            if (errors.Any())
                throw new ErrorLists("Erros encontrados:", errors);

            return Task.CompletedTask;
        }
        public static Task ValidateUpdateParams
            (
            UserParams @params
            )
        {
            var errors = new List<string>();

            if (@params.UserName != null && string.IsNullOrWhiteSpace(@params.UserName))
                errors.Add("Nome de usuário não pode estar vazio.");

            if (@params.Email != null && string.IsNullOrWhiteSpace(@params.Email))
                errors.Add("E-mail não pode estar vazio.");

            if (@params.Password != null && string.IsNullOrWhiteSpace(@params.Password))
                errors.Add("Senha não pode estar vazia.");

            if (errors.Any())
                throw new ErrorLists("Erros encontrados:", errors);

            return Task.CompletedTask;
        }
    }
}
