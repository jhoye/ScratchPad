using Scratch.Data;

namespace Scratch.Web.Models
{
    public class LoginViewModel : IAuthenticationRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAuthenticated { get; set; }

        public string ReturnUrl { get; set; }
    }
}