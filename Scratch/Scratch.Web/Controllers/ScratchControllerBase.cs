using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Scratch.Web.Controllers
{
    public abstract class ScratchControllerBase : Controller
    {
        private Components _componentsInstance;

        protected Components Components
        {
            get
            {
                return _componentsInstance ?? (_componentsInstance = Components.Access());
            }
        }

        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;

            using (var stringWriter = new StringWriter())
            {
                try
                {
                    var viewEngineResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

                    var viewContext = new ViewContext(ControllerContext, viewEngineResult.View, ViewData, TempData, stringWriter);
                    
                    viewEngineResult.View.Render(viewContext, stringWriter);
                    
                    viewEngineResult.ViewEngine.ReleaseView(ControllerContext, viewEngineResult.View);

                    var mvcHtmlString = new MvcHtmlString(stringWriter.GetStringBuilder().ToString());

                    return HttpUtility.HtmlDecode(mvcHtmlString.ToString().Trim());
                }
                catch (Exception exception)
                {
                    // TODO: handle exception

                    return null;
                }
            }
        }
    }
}