using System.Web.Mvc;
using Scratch.Web.Models.Toolbar;

namespace Scratch.Web.Controllers
{
    public class ToolbarController : ScratchControllerBase
    {
        public ActionResult Toolbar(ToolbarViewModel.MenuItems activeMenuItem = ToolbarViewModel.MenuItems.PageEditing)
        {
            return View(new ToolbarViewModel { ActiveMenuItem = activeMenuItem });
        }
    }
}