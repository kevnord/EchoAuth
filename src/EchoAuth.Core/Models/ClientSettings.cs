using System.Collections.Generic;

namespace EchoAuth.Core.Models
{
    public class ClientSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public HashSet<string> Domains { get; set; } = new HashSet<string>();
    }
}