using System;
using System.Web.Mvc;
using Scratch.Data.Core.DataModel;
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

        public ActionResult AddContentType()
        {
            var model = new ContentTypeViewModel();

            Components.ContentTypes.Load((IContentTypeHierarchy)model);

            return View("ContentType", model);
        }

        public ActionResult EditContentType(Guid id)
        {
            var model = new ContentTypeViewModel
            {
                Id = id
            };

            Components.ContentTypes.Load((IContentType)model);
            
            Components.ContentTypes.Load((IContentTypeHierarchy)model);

            return View("ContentType", model);
        }

        [HttpPost]
        public ActionResult SaveContentType(ContentTypeViewModel model)
        {
            Components.ContentTypes.Save(model);

            return RedirectToAction("EditContentType", new { id = model.Id });
        }

        public ActionResult DeleteContentType(Guid id)
        {
            var model = new ContentTypeViewModel
            {
                Id = id
            };

            Components.ContentTypes.Delete(model);

            return RedirectToAction("Index");
        }

        public ActionResult AddField(Guid id)
        {
            return View("Field", new FieldViewModel
            {
                ContentTypeId = id
            });
        }

        public ActionResult EditField(Guid id)
        {
            var model = new FieldViewModel
            {
                Id = id
            };

            Components.ContentTypes.Load(model);

            return View("Field", model);
        }

        [HttpPost]
        public ActionResult SaveField(FieldViewModel model)
        {
            Components.ContentTypes.Save(model);

            return RedirectToAction("EditContentType", new {id = model.ContentTypeId});
        }

        public ActionResult DeleteField(Guid id)
        {
            var model = new FieldViewModel { Id = id };

            Components.ContentTypes.Delete(model);

            return RedirectToAction("EditContentType", new { id = model.ContentTypeId });
        }
    }
}