using System.Web.Mvc;
using Scratch.Web.Helpers;
using Scratch.Web.Models.Authentication;

namespace Scratch.Web.Controllers
{
    public class AuthenticationController : ScratchControllerBase
    {
        public ActionResult Login(string returnUrl)
        {
            return View(
                new LoginViewModel
                {
                    IsAuthenticated = AuthenticationHelper.IsAuthenticated(),
                    ReturnUrl = returnUrl
                });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Components.Users.Authenticate(model);

            if (model.IsAuthenticated)
            {
                AuthenticationHelper.SetCookie(model.Username);
            }

            return View(model);
        }

        public ActionResult Logout(string returnUrl)
        {
            AuthenticationHelper.UnsetCookie();

            return View(new LogoutViewModel { ReturnUrl = returnUrl });
        }
    }
}