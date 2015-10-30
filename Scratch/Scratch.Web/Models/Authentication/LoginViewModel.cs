using Scratch.Data;

namespace Scratch.Web.Models.Authentication
{
    public class LoginViewModel : ViewModelBase, IAuthenticationRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAuthenticated { get; set; }

        public string ReturnUrl { get; set; }

        public LoginViewModel() : base(false)
        {
        }
    }
}