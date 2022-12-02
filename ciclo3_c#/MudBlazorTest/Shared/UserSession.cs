using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorTest.Shared
{
    public class UserSession
    {
        public string UserName { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }

    }
}
