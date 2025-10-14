namespace SignalR_Domains.Group
{
    public partial class Group
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid[] MemberIds { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Group() { }
    }
}
