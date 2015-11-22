using System.Web.Mvc;
using Scratch.Web.Models.Idea;

namespace Scratch.Web.Controllers
{
    public class IdeaController : Controller
    {
        public ActionResult Collect()
        {
            return View(new IdeaViewModel());
        }

        [HttpPost]
        public ActionResult Collect(IdeaViewModel model)
        {
            // TODO: collect idea

            return View(model);
        }
    }
}