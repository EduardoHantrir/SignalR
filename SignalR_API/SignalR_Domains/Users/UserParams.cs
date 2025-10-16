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
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public bool? IsActive { get; set; }

        public UserParams() { }
        public UserParams(User user)
        {
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            AvatarUrl = user.AvatarUrl;
            Description = user.Description;
            TimeZoneOffset = user.TimeZoneOffset;
            CreatedAt = DateTime.SpecifyKind((DateTime)user.CreatedAt!, DateTimeKind.Utc)
                           .AddHours((double)user.TimeZoneOffset!);
            LastUpdatedAt = DateTime.SpecifyKind((DateTime)user.LastUpdatedAt!, DateTimeKind.Utc)
                           .AddHours((double)user.TimeZoneOffset!);
            IsActive = user.IsActive;
        }
    }
}
