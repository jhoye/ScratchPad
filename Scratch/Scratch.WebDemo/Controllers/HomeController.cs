using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace Scratch.WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test()
        {
            var s = string.Empty;

            var test = new Test.Test();

            //s = new Test.Test().AlterProject("MyTest");
            s = test.GetPath();

            return Content(s);
        }
    }
}
