using System.Web.Mvc;
using Scratch.Web.Models.FileManager;

namespace Scratch.Web.Controllers
{
    public class FileManagerController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}