using Microsoft.AspNetCore.Mvc;
using Hitechsoft.CRM.Web.Controllers;

namespace Hitechsoft.CRM.Web.Public.Controllers
{
    public class AboutController : CRMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}