using System.Web.Mvc;
using Scratch.Web.Models.Search;

namespace Scratch.Web.Controllers
{
    public class SearchController : ScratchControllerBase
    {
        // GET: Search
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}