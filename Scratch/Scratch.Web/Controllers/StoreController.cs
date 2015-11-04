using System.Web.Mvc;
using Scratch.Web.Models.Store;

namespace Scratch.Web.Controllers
{
    public class StoreController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}