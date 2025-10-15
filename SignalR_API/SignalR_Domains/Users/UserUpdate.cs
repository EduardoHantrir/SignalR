using SignalR_Errors;

namespace SignalR_Domains.User
{
    public partial class User
    {
        public static async Task<User> Update(
            User @this,
            UserParams @params
            )
        {

            await UserValidator.ValidateUpdateParams(@params);


            if (@params.UserName != null)
                @this.UserName = @params.UserName;

            if (@params.Email != null)
                @this.Email = @params.Email;

            if (@params.Password != null)
                @this.Password = @params.Password;

            if (@params.AvatarUrl != null)
                @this.AvatarUrl = @params.AvatarUrl;

            if (@params.Description != null)
                @this.Description = @params.Description;

            if (@params.TimeZoneOffset != null)
                @this.TimeZoneOffset = (int)@params.TimeZoneOffset;

            if (@params.IsActive != null)
                @this.IsActive = (bool)@params.IsActive;

            @this.LastUpdatedAt = DateTime.UtcNow;

            return await Task.FromResult(@this);
        }
    }
}
