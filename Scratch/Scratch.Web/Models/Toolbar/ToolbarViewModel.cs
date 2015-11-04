namespace Scratch.Web.Models.Toolbar
{
    public class ToolbarViewModel
    {
        public enum MenuItems
        {
            PageEditing = 0,
            WebsiteAdmin = 1
        }

        public MenuItems ActiveMenuItem { get; set; }
    }
}