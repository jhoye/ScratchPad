using System.Web.Mvc;
using Scratch.Web.Models.SyndicatedContent;

namespace Scratch.Web.Controllers
{
    public class SyndicatedContentController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}