using System.Web.Mvc;
using Scratch.Web.Models.Navigation;

namespace Scratch.Web.Controllers
{
    public class NavigationController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}