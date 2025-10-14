namespace SignalR_Domains.Message
{
    public class MessageParams
    {
        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public string Content { get; set; }

        public MessageParams()
        {
        }

        public async Task<MessageParams> ValidateCreateParams()
        {
            await MessageValidator.ValidateCreateParams(this);
            return this;
        }
    }
}
