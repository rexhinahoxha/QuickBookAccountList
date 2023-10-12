using AuthenticationWebApp;
using AuthenticationWebApp.Models;
using Intuit.Ipp.OAuth2PlatformClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Authentication.Helper;

namespace AuthenticationWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Use the shared helper library to load the token json data
            // and initialize the OAuth2
            // client (Local.Client).
            LocalAuth.Initialize("..\\QBO.Shared\\Tokens.jsonc");

            // redirect the local host to
            // a generated authorization URL.
            return Redirect(AuthHelper.GetAuthorizationURL(OidcScopes.Accounting));
        }

        #region ASP.NET Default Code

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        #endregion
    }
}