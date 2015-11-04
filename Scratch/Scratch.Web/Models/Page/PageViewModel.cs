namespace Scratch.Web.Models
{
    public class PageViewModel : ViewModelBase
    {
        public string Slug { get; set; }

        public PageViewModel(bool showToolbar = false) : base(MenuItems.PageEditing, showToolbar)
        {
        }
    }
}