using System;
using System.Web.Mvc;
using Scratch.Web.Models;
using Scratch.Web.Models.ContentTypes;

namespace Scratch.Web.Controllers
{
    public class ContentTypesController : Controller
    {
        public ActionResult Index()
        {
            return Content("Content Types");
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