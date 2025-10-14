namespace SignalR_Domains.User
{
    public partial class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public int TimeZoneOffset { get; set; } = -3;
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public User() { }

        public override string ToString()
        {
            return $"{UserName}";
        }
    }
}
