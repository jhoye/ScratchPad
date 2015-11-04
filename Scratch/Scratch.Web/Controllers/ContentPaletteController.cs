using System;
using System.Web.Mvc;
using Scratch.Web.Models.ContentPalette;

namespace Scratch.Web.Controllers
{
    public class ContentPaletteController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        public ActionResult Add()
        {
            return Content("Add Content Type");
        }

        public ActionResult Edit(Guid id)
        {
            return Content("Edit Content Type: " + id);
        }

        [HttpPost]
        public ActionResult Save(ContentTypeViewModel model)
        {
            return Content("Save Content Type...");
        }

        [HttpPost]
        public ActionResult Delete(ContentTypeViewModel model)
        {
            return Content("Delete Content Type...");
        }
    }
}