using System.Web.Mvc;
using Scratch.Web.Models.Treeview;

namespace Scratch.Web.Controllers
{
    public class TreeviewController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel();

            return View(model);
        }
    }
}