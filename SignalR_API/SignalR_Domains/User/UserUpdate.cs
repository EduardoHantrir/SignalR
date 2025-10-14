namespace SignalR_Domains.User
{
    public class UserUpdate
    {
        public static async Task<User> Update(
            User @this,
            UserParams @params
            )
        {
            UserValidator.ValidateUpdateParams(@params).Wait();

            if (@params.UserName is not null)
                @this.UserName = @params.UserName;
            if (@params.Email is not null)
                @this.Email = @params.Email;
            if (@params.Password is not null)
                @this.Password = @params.Password;
            if (@params.AvatarUrl is not null)
                @this.AvatarUrl = @params.AvatarUrl;
            if (@params.Description is not null)
                @this.Description = @params.Description;
            if (@params.TimeZoneOffset is not null)
                @this.TimeZoneOffset = (int)@params.TimeZoneOffset;
            if (@params.IsActive is not null)
                @this.IsActive = (bool)@params.IsActive;
            @this.LastUpdatedAt = DateTime.UtcNow;

            return await Task.FromResult(@this);
        }
    }
}
