using System;
using System.Linq;
using System.Web;

namespace Scratch.Web.Helpers
{
    public static class AuthenticationHelper
    {
        private const string CookieName = "UserName";

        public static void SetCookie(string userName)
        {
            HttpContext.Current.Response.SetCookie(new HttpCookie(CookieName, userName) { Expires = DateTime.Now.AddDays(1) });
        }

        public static void UnsetCookie()
        {
            HttpContext.Current.Response.SetCookie(new HttpCookie(CookieName) { Expires = DateTime.Now.AddDays(-1) });
        }

        public static bool IsAuthenticated()
        {
            return HttpContext.Current.Request.Cookies.AllKeys.Contains(CookieName);
        }

        public static string GetUserName()
        {
            var cookies = HttpContext.Current.Request.Cookies;

            return cookies.AllKeys.Contains(CookieName) ? cookies[CookieName].Value : string.Empty;
        }
    }
}