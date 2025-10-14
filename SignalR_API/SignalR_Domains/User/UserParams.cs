namespace SignalR_Domains.User
{
    public class UserParams
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public int? TimeZoneOffset { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsActive { get; set; }

        public UserParams()
        {
        }

        public async Task<UserParams> ValidateCreateParams() 
        { 
            await UserValidator.ValidateCreateParams(this);
            return this;
        }
    }
}
