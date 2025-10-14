using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Domains.Message
{
    public class MessageValidator
    {
        public static async Task ValidateCreateParams(
            MessageParams @params
            )
        {
            if (@params.SenderId is null)
                throw new ArgumentNullException(nameof(@params.SenderId), "ID do remetente é obrigatório.");
            if (@params.ReceiverId is null)
                throw new ArgumentNullException(nameof(@params.ReceiverId), "ID do destinatário é obrigatório.");
            if (@params.Content is null)
                throw new ArgumentNullException(nameof(@params.Content), "Conteúdo da mensagem é obrigatório.");
            if (string.IsNullOrWhiteSpace(@params.Content))
                throw new ArgumentException("Conteúdo da mensagem não pode estar vazio.", nameof(@params.Content));
            await Task.CompletedTask;
        }
    }
}
