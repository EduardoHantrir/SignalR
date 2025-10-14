namespace SignalR_Domains.Group
{
    public partial class Group
    {
        public static async Task<Group> Create(
            GroupParams @params
            )
        {
            await GroupValidator.ValidateCreateParams(@params);

            var group = new Group
            {
                Id = Guid.NewGuid(),
                MemberIds = @params.MemberIds,
                Name = @params.Name,
                Description = @params.Description,
                CreatedAt = DateTime.UtcNow
            };

            return await Task.FromResult(group);
        }
    }
}
