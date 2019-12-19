using Microsoft.AspNetCore.Antiforgery;
using Shopping_Card.Controllers;

namespace Shopping_Card.Web.Host.Controllers
{
    public class AntiForgeryController : Shopping_CardControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
