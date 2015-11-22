using System.Web.Mvc;
using Scratch.Web.Models.Admin;

namespace Scratch.Web.Controllers
{
    public class AdminController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            // This action renders a dashboard; it emits a digest of: 
            //  - any problems with settings
            //  - a count of items in the GTD treeview inbox

            return View(new IndexViewModel());
        }

        public ActionResult About()
        {
            return View(new AboutViewModel());
        }
    }
}