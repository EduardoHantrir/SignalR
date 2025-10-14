namespace SignalR_Domains.User
{
    public partial class User
    {
        public static async Task<User> Create(
            UserParams @params
            )
        {
            await UserValidator.ValidateCreateParams(@params);

            var user = new User
            {
                UserName = @params.UserName,
                Email = @params.Email,
                Password = @params.Password,
                AvatarUrl = @params.AvatarUrl,
                Description = @params.Description,
                TimeZoneOffset = (int)@params.TimeZoneOffset,
                IsActive = true
            };

            return await Task.FromResult(user);
        }
    }
}
