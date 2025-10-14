
namespace SignalR_Domains.Message
{
    public partial class Message
    {
        public static async Task<Message> Create(
            MessageParams @params
            )
        {
            await MessageValidator.ValidateCreateParams(@params);

            var message = new Message
            {
                SenderId = (Guid)@params.SenderId,
                ReceiverId = (Guid)@params.ReceiverId,
                Content = @params.Content,
                IsRead = false
            };

            return await Task.FromResult(message);
        }
    }
}
