namespace Scratch.Web.Models
{
    public class PageViewModel
    {
        public enum MenuItems
        {
            PageEditing = 0,
            WebsiteAdmin = 1
        }

        public MenuItems ActiveMenuItem { get; set; }

        public bool ShowToolbar { get; set; }

        public string Slug { get; set; }

        public PageViewModel(bool showToolbar = false, MenuItems activeMenuItem = MenuItems.PageEditing)
        {
            ShowToolbar = showToolbar;
            ActiveMenuItem = activeMenuItem;
        }
    }
}