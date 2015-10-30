namespace Scratch.Web.Models
{
    public abstract class ViewModelBase
    {
        public enum MenuItems
        {
            PageEditing = 0,
            WebsiteAdmin = 1
        }

        public MenuItems ActiveMenuItem { get; set; }

        public bool ShowToolbar { get; set; }

        protected ViewModelBase(bool showToolbar = true, MenuItems activeMenuItem = MenuItems.WebsiteAdmin)
        {
            ShowToolbar = showToolbar;

            ActiveMenuItem = activeMenuItem;
        }
    }
}