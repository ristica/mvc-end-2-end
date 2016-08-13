using System.Web.Mvc;

namespace Demo.Controllers.Mvc
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}