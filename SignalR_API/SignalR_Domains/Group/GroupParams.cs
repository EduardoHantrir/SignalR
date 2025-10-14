using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Domains.Group
{
    public class GroupParams
    {
        public Guid[] MemberIds { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public GroupParams() { }
    }
}
