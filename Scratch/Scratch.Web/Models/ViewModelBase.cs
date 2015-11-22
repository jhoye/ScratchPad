using System.ComponentModel;

namespace Scratch.Web.Models
{
    public abstract class ViewModelBase : DependentBase
    {
        #region MenuItems enumeration

        public enum MenuItems
        {
            [Description("")]
            None,

            [Description("Page Editing")]
            PageEditing,

            [Description("Save Changes...")]
            PageEditing_SaveChanges,

            [Description("Content Palette")]
            PageEditing_ContentPalette,

            [Description("Edit Page")]
            PageEditing_EditPage,

            [Description("Add Page")]
            PageEditing_AddPage,

            [Description("Delete Page")]
            PageEditing_DeletePage,

            [Description("Webite Navigation")]
            PageEditing_WebsiteNavigation,

            [Description("File Manager")]
            PageEditing_FileManager,

            [Description("Webpage Analytics")]
            PageEditing_WebpageAnalytics,

            [Description("Website Admin")]
            WebsiteAdmin,
            
            [Description("Edit Content Palette")]
            WebsiteAdmin_EditContentPalette,
            
            [Description("Add Page")]
            WebsiteAdmin_AddPage,
            
            [Description("Delete Page")]
            WebsiteAdmin_DeletePage,
            
            [Description("Website Navigation")]
            WebsiteAdmin_WebsiteNavigation,
            
            [Description("Website Search")]
            WebsiteAdmin_WebsiteSearch,
            
            [Description("Web Forms")]
            WebsiteAdmin_WebForms,
            
            [Description("Store")]
            WebsiteAdmin_Store,
            
            [Description("Syndicated Content")]
            WebsiteAdmin_SyndicatedContent,
            
            [Description("File Manager")]
            WebsiteAdmin_FileManager,
            
            [Description("Website Analytics")]
            WebsiteAdmin_WebsiteAnalytics,
            
            [Description("Website Settings")]
            WebsiteAdmin_WebsiteSettings,
            
            [Description("Users")]
            WebsiteAdmin_Users,
            
            [Description("Idea Collector")]
            IdeaCollector,
            
            [Description("GTD Treeview")]
            Treeview,

            [Description("Log Out")]
            LogOut,

            [Description("About")]
            About
        }

        #endregion

        public MenuItems ActiveMenuItem { get; set; }

        public bool ShowToolbar { get; set; }

        protected ViewModelBase(MenuItems activeMenuItem, bool showToolbar = true)
        {
            ShowToolbar = showToolbar;

            ActiveMenuItem = activeMenuItem;
        }

        public bool IsActive(MenuItems menuItem)
        {
            return ActiveMenuItem.ToString().StartsWith(menuItem.ToString());
        }
    }
}