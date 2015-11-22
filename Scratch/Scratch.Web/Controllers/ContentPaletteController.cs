using System;
using System.Web.Mvc;
using Scratch.Web.Models.ContentPalette;

namespace Scratch.Web.Controllers
{
    public class ContentPaletteController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel();

            Components.ContentTypes.Load(model);

            return View(model);
        }

        public ActionResult Add()
        {
            return View("ContentType", new ContentTypeViewModel());
        }

        public ActionResult Edit(Guid id)
        {
            var model = new ContentTypeViewModel
            {
                Id = id
            };

            Components.ContentTypes.Load(model);

            return View("ContentType", model);
        }

        [HttpPost]
        public ActionResult Save(ContentTypeViewModel model)
        {
            Components.ContentTypes.Save(model);

            return RedirectToAction("Edit", new { id = model.Id });
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var model = new ContentTypeViewModel
            {
                Id = id
            };

            Components.ContentTypes.Delete(model);

            return RedirectToAction("Index");
        }
    }
}