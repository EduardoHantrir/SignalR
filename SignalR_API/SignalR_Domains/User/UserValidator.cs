namespace SignalR_Domains.User
{
    public class UserValidator
    {
        public static async Task ValidateCreateParams(
            UserParams @params
            )
        {
            if (@params.UserName is null)
                throw new ArgumentNullException(nameof(@params.UserName), "Nome de usuário é obrigatório.");

            if (@params.Email is null)
                throw new ArgumentNullException(nameof(@params.Email), "E-mail é obrigatório.");

            if (@params.Password is null)
                throw new ArgumentNullException(nameof(@params.Password), "Senha é obrigatória.");

            if (@params.TimeZoneOffset is null)
                @params.TimeZoneOffset = -3;

            await Task.CompletedTask;
        }
        public static async Task ValidateUpdateParams(
            UserParams @params
            )
        {
            if (@params.UserName is not null && string.IsNullOrWhiteSpace(@params.UserName))
                throw new ArgumentException("Nome de usuário não pode estar vazio.", nameof(@params.UserName));

            if (@params.Email is not null && string.IsNullOrWhiteSpace(@params.Email))
                throw new ArgumentException("E-mail não pode estar vazio.", nameof(@params.Email));

            if (@params.Password is not null && string.IsNullOrWhiteSpace(@params.Password))
                throw new ArgumentException("Senha não pode estar vazia.", nameof(@params.Password));

            await Task.CompletedTask;
        }
    }
}
