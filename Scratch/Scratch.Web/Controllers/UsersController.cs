using System.Web.Mvc;
using Scratch.Web.Models.Users;

namespace Scratch.Web.Controllers
{
    public class UsersController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }
    }
}