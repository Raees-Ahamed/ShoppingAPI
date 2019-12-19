using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Shopping_Card.Controllers;

namespace Shopping_Card.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : Shopping_CardControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
