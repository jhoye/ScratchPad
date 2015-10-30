using System;
using System.Web.Mvc;
using Scratch.Web.Helpers;
using Scratch.Web.Models;

namespace Scratch.Web.Controllers
{
    public class PageController : ScratchControllerBase
    {
        [HttpGet]
        public ActionResult Get(string slug = "")
        {
            try
            {
                if (AuthenticationHelper.IsAuthenticated())
                {
                    return View(new PageViewModel(true) { Slug = slug });
                }
                
                return Content(Components.Cache.Get(slug) ?? "404");
            }
            catch (Exception)
            {
                return Content("500");
            }
        }
    }
}