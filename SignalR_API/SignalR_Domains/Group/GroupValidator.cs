using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Domains.Group
{
    public class GroupValidator
    {
        public static async Task ValidateCreateParams(GroupParams @params)
        {
            if (@params.MemberIds == null || @params.MemberIds.Length < 2)
            {
                throw new ArgumentException("Um grupo deve ter pelo menos dois menbros.");
            }
            if (string.IsNullOrWhiteSpace(@params.Name))
            {
                throw new ArgumentException("O nome do grupo não deve ser vazio.");
            }
            await Task.CompletedTask;
        }
    }
}
