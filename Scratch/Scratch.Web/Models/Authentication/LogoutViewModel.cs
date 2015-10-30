namespace Scratch.Web.Models.Authentication
{
    public class LogoutViewModel : ViewModelBase
    {
        public string ReturnUrl { get; set; }

        public LogoutViewModel() : base(false)
        {
        }
    }
}