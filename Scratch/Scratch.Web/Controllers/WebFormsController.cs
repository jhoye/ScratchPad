using System.Web.Mvc;
using Scratch.Web.Models.WebForms;

namespace Scratch.Web.Controllers
{
    public class WebFormsController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}