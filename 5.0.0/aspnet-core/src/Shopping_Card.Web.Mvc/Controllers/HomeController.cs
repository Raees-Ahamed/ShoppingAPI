using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Shopping_Card.Controllers;

namespace Shopping_Card.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Shopping_CardControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
