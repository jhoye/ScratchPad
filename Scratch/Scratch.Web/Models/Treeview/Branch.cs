using System.Collections.Generic;
using System.ComponentModel;

namespace Scratch.Web.Models.Treeview
{
    public class Branch
    {
        #region BranchTypes enumeration

        public enum BranchTypes
        {
            [Description("Inbox")]
            Inbox,

            [Description("Today's Schedule")]
            Inbox_TodaysSchedule,

            [Description("Today's Tickler")]
            Inbox_TodaysTickler,

            [Description("Purchase Orders")]
            Inbox_PurchaseOrders,

            [Description("Form Submissions")]
            Inbox_FormSubmissions,

            [Description("Blog Comments")]
            Inbox_BlogComments,

            [Description("Ideas")]
            Inbox_Ideas,

            [Description("Lists")]
            Lists,

            [Description("Projects")]
            Lists_Projects,

            [Description("Next Actions")]
            Lists_NextActions,

            [Description("Waiting For...")]
            Lists_WaitingFor,

            [Description("Someday / Maybe")]
            Lists_SomedayMaybe,

            [Description("At Computer")]
            Lists_AtComputer,

            [Description("Away From Computer")]
            Lists_AwayFromComputer,

            [Description("Errands")]
            Lists_Errands,

            [Description("Calls")]
            Lists_Calls,

            [Description("Agendas")]
            Lists_Agendas,

            [Description("Calendar")]
            Calendar,

            [Description("Reference Materials")]
            ReferenceMaterials,

            [Description("Tickler Files")]
            TicklerFiles
        }

        #endregion

        public readonly BranchTypes Type;

        public readonly bool HasChildren;

        public List<Branch> Branches { get; set; }

        public Branch(BranchTypes type, bool hasChildren = false)
        {
            Type = type;

            HasChildren = hasChildren;

            Branches = new List<Branch>();
        }
    }
}