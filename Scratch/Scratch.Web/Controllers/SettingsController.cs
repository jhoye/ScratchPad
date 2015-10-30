using System.Web.Mvc;
using Scratch.Web.Models.Settings;

namespace Scratch.Web.Controllers
{
    public class SettingsController : Controller
    {
        public ActionResult Index()
        {
            return View(new SettingsViewModel());
        }
    }
}