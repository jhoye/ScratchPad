using System.Web.Mvc;
using Scratch.Web.Models.Settings;

namespace Scratch.Web.Controllers
{
    public class SettingsController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        public ActionResult Cache()
        {
            var model = new CacheSettings
            {
                Status = SettingsBase.Statuses.Green,
                StatusMessage = "Okay."
            };

            return View(model);
        }

        public ActionResult Database()
        {
            var model = new DatabaseSettings
            {
                Status = SettingsBase.Statuses.Green,
                StatusMessage = "Okay."
            };

            return View(model);
        }

        public ActionResult Email()
        {
            System.Threading.Thread.Sleep(3000);

            var model = new EmailSettings
            {
                Status = SettingsBase.Statuses.Green,
                StatusMessage = "Okay."
            };

            return View(model);
        }
    }
}