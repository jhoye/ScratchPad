using System.Web.Mvc;
using Scratch.Web.Models.Analytics;

namespace Scratch.Web.Controllers
{
    public class AnalyticsController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}