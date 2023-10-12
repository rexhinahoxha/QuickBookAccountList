using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class AuthToken
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? RealmId { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string RedirectUrl { get; set; } = "https://liferay-support.zendesk.com/hc/article_attachments/360030162971/your-request-completed-successfully.png";
        public string Environment { get; set; } = "sandbox";
    }
}
